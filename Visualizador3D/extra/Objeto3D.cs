using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visualizador3D.extra
{
    class Objeto3D
    {
        private List<Ponto3D> vertsOri, vertsAt;
        private double[,] ma;
        private List<List<int>> faces, listaFacesVertices;
        private Ponto3D[] vetNorfaces, vetNorvertices;
        private double mx, my, mz, lx, ly, lz;
        private Ponto3D pCentro;

        private void inicializa()
        {

            faces = new List<List<int>>();
            vertsOri = new List<Ponto3D>();
            vertsAt = new List<Ponto3D>();
            listaFacesVertices = new List<List<int>>();

            ma = novaMatrizIdentidade(4);
        }
        
        private Objeto3D()
        {

        }

        public Objeto3D(string caminho)
        {
            inicializa();
            lerObjeto3D(caminho);
        }

        public Objeto3D getCopia()
        {
            Objeto3D o = new Objeto3D();
            o.pCentro = new Ponto3D(0, 0, 0);
            o.vertsOri = this.vertsOri;
            o.faces = this.faces;
            o.listaFacesVertices = this.listaFacesVertices;
            o.vetNorfaces = this.vetNorfaces;
            o.vetNorfaces = (Ponto3D[])this.vetNorfaces.Clone();
            o.ma = cloneMat(this.ma);
            //o.translacao((int)-pcentro.getX(), (int)-pcentro.getY(), (int)-pcentro.getZ());
            return o;
        }

        private double[,] novaMatrizIdentidade(int ordem)
        {
            double[,] mat = new double[ordem, ordem];
            for (int i = 0; i < ordem; ++i)
                mat[i, i] = 1;
            return mat;
        }
        public double[,] cloneMat(double[,] mat)
        {
            double[,] nova = new double[mat.GetLength(0), mat.GetLength(1)];
            for (int i = 0; i < mat.GetLength(0); ++i)
                for (int j = 0; j < mat.GetLength(1); ++j)
                    nova[i, j] = mat[i, j];
            return nova;
        }


        public void lerObjeto3D(String caminho)
        {
            string linha;
            string[] vs, vs2;
            double x, y, z, xm, ym, zm;
            this.mx = this.my = this.mz = this.lx = this.ly = this.lz = xm = ym = zm = 0;
            int idx, d;
            List<int> face;
            FileStream file = File.OpenRead(caminho);
            StreamReader read = new StreamReader(file);
            while ((linha = read.ReadLine()) != null)
            {
                linha = linha.Trim();
 
                if (linha.Length > 0)
                {
                    vs = linha.Split(' ');
                    if (vs[0] == "v")
                    {
                        double.TryParse(vs[1].Replace('.', ','), out x);
                        double.TryParse(vs[2].Replace('.', ','), out y);
                        double.TryParse(vs[3].Replace('.', ','), out z);
                        xm += x;
                        ym += y;
                        zm += z;
                        if (x > this.mx)
                            this.mx = x;
                        else if (x < this.lx)
                            this.lx = x;
                        if (y > this.my)
                            this.my = y;
                        else if (y < this.ly)
                            this.ly = y;
                        if (z > this.mz)
                            this.mz = z;
                        else if (z < this.lz)
                            this.lz = z;
                        addVertice(new Ponto3D(x, y, z));
                        listaFacesVertices.Add(new List<int>());
                    }
                    else if (vs[0] == "f")
                    {
                        face = new List<int>();
                        for (int i = 1; i < vs.Length; ++i)
                        {
                            vs2 = vs[i].Split('/');
                            idx = int.Parse(vs2[0]) - 1;
                            face.Add(idx);
                            listaFacesVertices[idx].Add(faces.Count);
                        }
                        addFace(face);
                    }
                }
            }
            d = vertsOri.Count;
            this.pCentro = new Ponto3D(xm / d, ym / d, zm / d);
            read.Close();
            file.Close();
            calculaVetoresNormais(); 
        }
        private void inicializaVetoresNormais()
        {
            vetNorfaces = new Ponto3D[faces.Count];
            vetNorvertices = new Ponto3D[vertsOri.Count];
        }
        private void calculaVetoresNormais()
        {
            Ponto3D vn;
            inicializaVetoresNormais();
            
            for (int i = 0; i < faces.Count; ++i)
            {
                vn = novoVetNormal(faces[i]);
                vn = vn.normalizar();
                vetNorfaces[i] = vn;
            }
        }

        private Ponto3D novoVetNormal(List<int> face)
        {
            Ponto3D a, b, n;
            a = vertsAt[face[0]];
            b = vertsAt[face[1]];
            n = vertsAt[face[face.Count - 1]];
            Ponto3D ab = b.menos(a);
            Ponto3D an = n.menos(a);
            Ponto3D vn = ab.produtoVetorial(an);
            return vn;
        }

        public ET gerarETFaceFlat(int f, int height, int tx, int ty, Ponto3D Luz, Ponto3D Eye, int n,
            Ponto3D ia, Ponto3D id, Ponto3D ie, Ponto3D ka, Ponto3D kd, Ponto3D ke)
        {

            ET et = new ET(height + 1);
            double xmax, ymax, zmax, xmin, ymin, zmin, dx, dy, dz, incx, incz;
            int y;
            Ponto3D cor;
            List<int> face = faces[f];
            cor = Desenha.corPhong(Luz, Eye, vetNorfaces[f], n, ia, id, ie, ka, kd, ke);
            for (int i = 0; i + 1 < face.Count; ++i)
            { 
                if (vertsAt[face[i]].getY() >= vertsAt[face[i + 1]].getY())
                {
                    xmax = vertsAt[face[i]].getX();
                    ymax = vertsAt[face[i]].getY();
                    zmax = vertsAt[face[i]].getZ();
                    xmin = vertsAt[face[i + 1]].getX();
                    ymin = vertsAt[face[i + 1]].getY();
                    zmin = vertsAt[face[i + 1]].getZ();

                }
                else
                {
                    xmin = vertsAt[face[i]].getX();
                    ymin = vertsAt[face[i]].getY();
                    zmin = vertsAt[face[i]].getZ();
                    xmax = vertsAt[face[i + 1]].getX();
                    ymax = vertsAt[face[i + 1]].getY();
                    zmax = vertsAt[face[i + 1]].getZ();
                }
                dx = xmax - xmin;
                dy = ymax - ymin;
                dz = zmax - zmin;

                incx = (dy != 0) ? dx / dy : 0;
                incz = dy != 0 ? dz / dy : 0;

                y = (int)ymin + ty;
                if (y < 0) y = 0;
                else if (y >= height) y = height - 1;
                if (et.getAET(y) == null)
                    et.init(y);
                et.getAET(y).add(new NoAET((int)ymax + ty, xmin + tx, incx, zmin, incz,
                    cor.getX(), cor.getY(), cor.getZ(), 0, 0, 0));
            }// fim for
             // ultimo com o primeiro
            if (vertsAt[face[0]].getY() >= vertsAt[face[face.Count - 1]].getY())
            {
                xmax = vertsAt[face[0]].getX();
                ymax = vertsAt[face[0]].getY();
                zmax = vertsAt[face[0]].getZ();
                xmin = vertsAt[face[face.Count - 1]].getX();
                ymin = vertsAt[face[face.Count - 1]].getY();
                zmin = vertsAt[face[face.Count - 1]].getZ();
            }
            else
            {
                xmin = vertsAt[face[0]].getX();
                ymin = vertsAt[face[0]].getY();
                zmin = vertsAt[face[0]].getZ();
                xmax = vertsAt[face[face.Count - 1]].getX();
                ymax = vertsAt[face[face.Count - 1]].getY();
                zmax = vertsAt[face[face.Count - 1]].getZ();
            }
            dx = xmax - xmin;
            dy = ymax - ymin;
            dz = zmax - zmin;

            incx = (dy != 0) ? dx / dy : 0;
            incz = dy != 0 ? dz / dy : 0;

            y = (int)ymin + ty;
            if (y < 0) y = 0;
            else if (y >= height) y = height - 1;
            if (et.getAET(y) == null)
                et.init(y);
            et.getAET(y).add(new NoAET((int)ymax + ty, xmin + tx, incx, zmin, incz,
                cor.getX(), cor.getY(), cor.getZ(), 0, 0, 0));
            return et;
        }

        public void addVertice(Ponto3D p)
        {
            vertsOri.Add(p);
            vertsAt.Add(p);
        }
        public void addFace(List<int> f)
        {
            faces.Add(f);
        }
        public void atualizaVetoresNormaisFaces()
        {
            calculaVetoresNormais();
        }
        private Ponto3D mediaVetsNormais(List<Ponto3D> normais)
        {
            double x, y, z, d = normais.Count;
            x = y = z = 0;
            foreach (Ponto3D v in normais)
            {
                x += v.getX();
                y += v.getY();
                z += v.getZ();
            }
            return new Ponto3D(x / d, y / d, z / d);
        }

        public ET gerarETFaceGouraud(int f, int height, int tx, int ty, Ponto3D Luz, Ponto3D Eye, int n,
            Ponto3D ia, Ponto3D id, Ponto3D ie, Ponto3D ka, Ponto3D kd, Ponto3D ke)
        {
            Ponto3D cl, cm;
            ET et = new ET(height + 1);
            double xmax, ymax, zmax, xmin, ymin, zmin, dx, dy, dz;
            double incx, incz, incrx, incgy, incbz;
            int y;
            List<int> face = faces[f];
            for (int i = 0; i + 1 < face.Count; ++i)
            { // do primeiro ponto até o ultimo
                if (vertsAt[face[i]].getY() >= vertsAt[face[i + 1]].getY())
                {
                    xmax = vertsAt[face[i]].getX();
                    ymax = vertsAt[face[i]].getY();
                    zmax = vertsAt[face[i]].getZ();
                    cm = Desenha.corPhong(Luz, Eye, vetNorvertices[face[i]], n, ia, id, ie, ka, kd, ke);
                    xmin = vertsAt[face[i + 1]].getX();
                    ymin = vertsAt[face[i + 1]].getY();
                    zmin = vertsAt[face[i + 1]].getZ();
                    cl = Desenha.corPhong(Luz, Eye, vetNorvertices[face[i + 1]], n, ia, id, ie, ka, kd, ke);

                }
                else
                {
                    xmin = vertsAt[face[i]].getX();
                    ymin = vertsAt[face[i]].getY();
                    zmin = vertsAt[face[i]].getZ();
                    cl = Desenha.corPhong(Luz, Eye, vetNorvertices[face[i]], n, ia, id, ie, ka, kd, ke);
                    xmax = vertsAt[face[i + 1]].getX();
                    ymax = vertsAt[face[i + 1]].getY();
                    zmax = vertsAt[face[i + 1]].getZ();
                    cm = Desenha.corPhong(Luz, Eye, vetNorvertices[face[i + 1]], n, ia, id, ie, ka, kd, ke);
                }
                dx = xmax - xmin;
                dy = ymax - ymin;
                dz = zmax - zmin;

                incx = (dy != 0) ? dx / dy : 0;
                incz = dy != 0 ? dz / dy : 0;
                incrx = (cm.getX() - cl.getX()) / dy;
                incgy = (cm.getY() - cl.getY()) / dy;
                incbz = (cm.getZ() - cl.getZ()) / dy;

                y = (int)ymin + ty;
                if (y < 0) y = 0;
                else if (y >= height) y = height - 1;
                if (et.getAET(y) == null)
                    et.init(y);
                et.getAET(y).add(new NoAET((int)ymax + ty, xmin + tx, incx, zmin, incz,
                    cl.getX(), cl.getY(), cl.getZ(), incrx, incgy, incbz));
            }// fim for
             // ultimo com o primeiro
            if (vertsAt[face[0]].getY() >= vertsAt[face[face.Count - 1]].getY())
            {
                xmax = vertsAt[face[0]].getX();
                ymax = vertsAt[face[0]].getY();
                zmax = vertsAt[face[0]].getZ();
                cm = Desenha.corPhong(Luz, Eye, vetNorvertices[face[0]], n, ia, id, ie, ka, kd, ke);
                xmin = vertsAt[face[face.Count - 1]].getX();
                ymin = vertsAt[face[face.Count - 1]].getY();
                zmin = vertsAt[face[face.Count - 1]].getZ();
                cl = Desenha.corPhong(Luz, Eye, vetNorvertices[face[face.Count - 1]], n, ia, id, ie, ka, kd, ke);
            }
            else
            {
                xmin = vertsAt[face[0]].getX();
                ymin = vertsAt[face[0]].getY();
                zmin = vertsAt[face[0]].getZ();
                cl = Desenha.corPhong(Luz, Eye, vetNorvertices[face[0]], n, ia, id, ie, ka, kd, ke);
                xmax = vertsAt[face[face.Count - 1]].getX();
                ymax = vertsAt[face[face.Count - 1]].getY();
                zmax = vertsAt[face[face.Count - 1]].getZ();
                cm = Desenha.corPhong(Luz, Eye, vetNorvertices[face[face.Count - 1]], n, ia, id, ie, ka, kd, ke);
            }
            dx = xmax - xmin;
            dy = ymax - ymin;
            dz = zmax - zmin;

            incx = (dy != 0) ? dx / dy : 0;
            incz = dy != 0 ? dz / dy : 0;
            incrx = (cm.getX() - cl.getX()) / dy;
            incgy = (cm.getY() - cl.getY()) / dy;
            incbz = (cm.getZ() - cl.getZ()) / dy;

            y = (int)ymin + ty;
            if (y < 0) y = 0;
            else if (y >= height) y = height - 1;
            if (et.getAET(y) == null)
                et.init(y);
            et.getAET(y).add(new NoAET((int)ymax + ty, xmin + tx, incx, zmin, incz,
                cl.getX(), cl.getY(), cl.getZ(), incrx, incgy, incbz));
            return et;
        }
        internal ET gerarETFacePhong(int f, int height, int tx, int ty, Ponto3D luz, Ponto3D eye, int n, Ponto3D ia, Ponto3D id, Ponto3D ie, Ponto3D ka, Ponto3D kd, Ponto3D ke)
        {
            ET et = new ET(height + 1);
            double xmax, ymax, zmax, xmin, ymin, zmin, dx, dy, dz, rl, rm, gl, gm, bl, bm;
            double incx, incz, incrx, incgy, incbz;
            int y;
            List<int> face = faces[f];
            for (int i = 0; i + 1 < face.Count; ++i)
            { 
                if (vertsAt[face[i]].getY() >= vertsAt[face[i + 1]].getY())
                {
                    xmax = vertsAt[face[i]].getX();
                    ymax = vertsAt[face[i]].getY();
                    zmax = vertsAt[face[i]].getZ();
                    rm = vetNorvertices[face[i]].getX();
                    gm = vetNorvertices[face[i]].getY();
                    bm = vetNorvertices[face[i]].getZ();
                    xmin = vertsAt[face[i + 1]].getX();
                    ymin = vertsAt[face[i + 1]].getY();
                    zmin = vertsAt[face[i + 1]].getZ();
                    rl = vetNorvertices[face[i + 1]].getX();
                    gl = vetNorvertices[face[i + 1]].getY();
                    bl = vetNorvertices[face[i + 1]].getZ();

                }
                else
                {
                    xmin = vertsAt[face[i]].getX();
                    ymin = vertsAt[face[i]].getY();
                    zmin = vertsAt[face[i]].getZ();
                    rl = vetNorvertices[face[i]].getX();
                    gl = vetNorvertices[face[i]].getY();
                    bl = vetNorvertices[face[i]].getZ();
                    xmax = vertsAt[face[i + 1]].getX();
                    ymax = vertsAt[face[i + 1]].getY();
                    zmax = vertsAt[face[i + 1]].getZ();
                    rm = vetNorvertices[face[i + 1]].getX();
                    gm = vetNorvertices[face[i + 1]].getY();
                    bm = vetNorvertices[face[i + 1]].getZ();
                }
                dx = xmax - xmin;
                dy = ymax - ymin;
                dz = zmax - zmin;

                incx = (dy != 0) ? dx / dy : 0;
                incz = dy != 0 ? dz / dy : 0;
                incrx = (rm - rl) / dy;
                incgy = (gm - gl) / dy;
                incbz = (bm - bl) / dy;

                y = (int)ymin + ty;
                if (y < 0) y = 0;
                else if (y >= height) y = height - 1;
                if (et.getAET(y) == null)
                    et.init(y);
                et.getAET(y).add(new NoAET((int)ymax + ty, xmin + tx, incx, zmin, incz,
                    rl, gl, bl, incrx, incgy, incbz));
            }
            if (vertsAt[face[0]].getY() >= vertsAt[face[face.Count - 1]].getY())
            {
                xmax = vertsAt[face[0]].getX();
                ymax = vertsAt[face[0]].getY();
                zmax = vertsAt[face[0]].getZ();
                rm = vetNorvertices[face[0]].getX();
                gm = vetNorvertices[face[0]].getY();
                bm = vetNorvertices[face[0]].getZ();
                xmin = vertsAt[face[face.Count - 1]].getX();
                ymin = vertsAt[face[face.Count - 1]].getY();
                zmin = vertsAt[face[face.Count - 1]].getZ();
                rl = vetNorvertices[face[face.Count - 1]].getX();
                gl = vetNorvertices[face[face.Count - 1]].getY();
                bl = vetNorvertices[face[face.Count - 1]].getZ();
            }
            else
            {
                xmin = vertsAt[face[0]].getX();
                ymin = vertsAt[face[0]].getY();
                zmin = vertsAt[face[0]].getZ();
                rl = vetNorvertices[face[0]].getX();
                gl = vetNorvertices[face[0]].getY();
                bl = vetNorvertices[face[0]].getZ();
                xmax = vertsAt[face[face.Count - 1]].getX();
                ymax = vertsAt[face[face.Count - 1]].getY();
                zmax = vertsAt[face[face.Count - 1]].getZ();
                rm = vetNorvertices[face[face.Count - 1]].getX();
                gm = vetNorvertices[face[face.Count - 1]].getY();
                bm = vetNorvertices[face[face.Count - 1]].getZ();
            }
            dx = xmax - xmin;
            dy = ymax - ymin;
            dz = zmax - zmin;

            incx = (dy != 0) ? dx / dy : 0;
            incz = dy != 0 ? dz / dy : 0;
            incrx = (rm - rl) / dy;
            incgy = (gm - gl) / dy;
            incbz = (bm - bl) / dy;

            y = (int)ymin + ty;
            if (y < 0) y = 0;
            else if (y >= height) y = height - 1;
            if (et.getAET(y) == null)
                et.init(y);
            et.getAET(y).add(new NoAET((int)ymax + ty, xmin + tx, incx, zmin, incz,
                rl, gl, bl, incrx, incgy, incbz));
            return et;
        }
        public void atualizaVetoresNormaisVertices()
        {
            for (int i = 0; i < vetNorvertices.Length; ++i)
            {
                List<Ponto3D> normais = new List<Ponto3D>();
                foreach (int j in listaFacesVertices[i])
                    normais.Add(vetNorfaces[j]);
                vetNorvertices[i] = mediaVetsNormais(normais);
            }
        }

        private void atualizaVertices()
        {
            Ponto3D p;
            double[,] matp;
            double x, y, z;
            x = y = z = 0;
            mx = my = mz = 0;
            lx = ly = lz = int.MaxValue;
            vertsAt = new List<Ponto3D>();
            for (int i = 0; i < vertsOri.Count; ++i)
            {
                p = vertsOri[i];
                matp = multiplicar(ma, ponto3D2Matriz(p));
                // atualizando verticesAtuais
                vertsAt.Add(new Ponto3D(matp[0, 0], matp[1, 0], matp[2, 0]));
                x += matp[0, 0]; y += matp[1, 0]; z += matp[2, 0];
                if (matp[0, 0] > mx) mx = matp[0, 0];
                else if (matp[0, 0] < lx) lx = matp[0, 0];
                if (matp[1, 0] > my) my = matp[1, 0];
                else if (matp[1, 0] < ly) ly = matp[1, 0];
            }
            // atualizando centro
            int d = vertsOri.Count;
            pCentro = new Ponto3D(Math.Round(x / d), Math.Round(y / d), Math.Round(z / d));
        }

        public void rotacaoZ(double r, bool rmfacesOcultas) // radianos
        {
            Ponto3D centro = getCentro();
            int tx = (int)Math.Round(centro.getX());
            int ty = (int)Math.Round(centro.getY());
            int tz = (int)Math.Round(centro.getZ());
            double[,] rot = novaMatrizIdentidade(4);
            rot[0, 0] = Math.Cos(r); rot[0, 1] = -Math.Sin(r);
            rot[1, 0] = Math.Sin(r); rot[1, 1] = Math.Cos(r);
            if (!(tx == 0 && ty == 0 && tz == 0))
            {
                //translacao(-tx, -ty, -tz);
                ma = multiplicar(rot, ma);
                //translacao(tx, ty, tz);
            }
            else
                ma = multiplicar(rot, ma);
            atualizaVertices();
            if (rmfacesOcultas)
                atualizaVetoresNormaisFaces();
        }

        public void rotacaoX(double r, bool rmfacesOcultas)
        {
            Ponto3D centro = getCentro();
            int tx = (int)Math.Round(centro.getX());
            int ty = (int)Math.Round(centro.getY());
            int tz = (int)Math.Round(centro.getZ());
            double[,] rot = novaMatrizIdentidade(4);
            rot[1, 1] = Math.Cos(r); rot[1, 2] = -Math.Sin(r);
            rot[2, 1] = Math.Sin(r); rot[2, 2] = Math.Cos(r);
            if (!(tx == 0 && ty == 0 && tz == 0))
            {
                //translacao(-tx, -ty, -tz);
                ma = multiplicar(rot, ma);
                //translacao(tx, ty, tz);
            }
            else
                ma = multiplicar(rot, ma);
            atualizaVertices();
            if (rmfacesOcultas)
                atualizaVetoresNormaisFaces();
        }

        public void rotacaoY(double r, bool rmfacesOcultas)
        {
            Ponto3D centro = getCentro();
            int tx = (int)Math.Round(centro.getX());
            int ty = (int)Math.Round(centro.getY());
            int tz = (int)Math.Round(centro.getZ());
            double[,] rot = novaMatrizIdentidade(4);
            rot[0, 0] = Math.Cos(r); rot[0, 2] = Math.Sin(r);
            rot[2, 0] = -Math.Sin(r); rot[2, 2] = Math.Cos(r);
            if (!(tx == 0 && ty == 0 && tz == 0))
            {
                //translacao(-tx, -ty, -tz);
                ma = multiplicar(rot, ma);
                //translacao(tx, ty, tz);
            }
            else
                ma = multiplicar(rot, ma);
            atualizaVertices();
            if (rmfacesOcultas)
                atualizaVetoresNormaisFaces();
        }

        public double[,] ponto3D2Matriz(Ponto3D p)
        {
            double[,] matp = new double[4, 1];
            matp[0, 0] = p.getX();
            matp[1, 0] = p.getY();
            matp[2, 0] = p.getZ();
            matp[3, 0] = 1;
            return matp;
        }

        public void escala(double sx, double sy, double sz)
        {
            Ponto3D centro = getCentro();
            int tx = (int)Math.Round(centro.getX());
            int ty = (int)Math.Round(centro.getY());
            int tz = (int)Math.Round(centro.getZ());
            double[,] esc = novaMatrizIdentidade(4);
            esc[0, 0] = sx;
            esc[1, 1] = sy;
            esc[2, 2] = sz;
            //translacao(-tx, -ty, -tz);
            ma = multiplicar(esc, ma);
            //translacao(tx, ty, tz);
            atualizaVertices();
        }

        private double[,] multiplicar(double[,] m1, double[,] m2)
        {
            int l1 = m1.GetLength(0), c1 = m1.GetLength(1);
            int l2 = m1.GetLength(0), c2 = m2.GetLength(1);
            // GetLength(idx) retorna a quantidade de valores na dimenssão idx
            double[,] mat = new double[l1, c2];
            for (int i = 0; i < l1; ++i) // linha da primeira
                for (int j = 0; j < c2; ++j) // coluna da segunda
                    for (int k = 0; k < l1; ++k) // linha da seg ou coluna da prim
                        mat[i, j] += m1[i, k] * m2[k, j];
            return mat;
        }

        public Ponto3D getCentro()
        {
            return pCentro;
        }

        public List<List<int>> getFaces()
        {
            return faces;
        }

        public Ponto3D getVetNorFace(int id)
        {
            return vetNorfaces[id];
        }

        public List<Ponto3D> getVertices()
        {
            return vertsAt;
        }
        public int getMaxX()
        {
            return (int)Math.Round(mx);
        }

        public int getMinX()
        {
            return (int)Math.Round(lx);
        }

        public int getMaxY()
        {
            return (int)Math.Round(my);
        }

        public int getMinY()
        {
            return (int)Math.Round(ly);
        }
    }
}
