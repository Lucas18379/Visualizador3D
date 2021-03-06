using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visualizador3D.extra
{
    class Desenha
    {
        private const double pi = Math.PI;
        private int cx, cy;

        public static Ponto3D corPhong(Ponto3D Luz, Ponto3D Eye, Ponto3D N, int n,
            Ponto3D ia, Ponto3D id, Ponto3D ie, Ponto3D ka, Ponto3D kd, Ponto3D ke)
        {           
            Ponto3D H = Luz.mais(Eye).normalizar();
            double hnn = Math.Pow(H.produtoEscalar(N), n), ln = Luz.produtoEscalar(N);

            double r = ia.getX() * ka.getX() + id.getX() * kd.getX() * ln + ie.getX() * ke.getX() * hnn;
            double g = ia.getY() * ka.getY() + id.getY() * kd.getY() * ln + ie.getY() * ke.getY() * hnn;
            double b = ia.getZ() * ka.getZ() + id.getZ() * kd.getZ() * ln + ie.getZ() * ke.getZ() * hnn;
            r = r < 0 ? 0 : (r > 1 ? 1 : r);
            g = g < 0 ? 0 : (g > 1 ? 1 : g);
            b = b < 0 ? 0 : (b > 1 ? 1 : b);
            return new Ponto3D(r * 255, g * 255, b * 255);
        }

        private double abs(double a)
        {
            return Math.Abs(a);
        }

        private int abs(int a)
        {
            return Math.Abs(a);
        }

        private double[,] gerarZBuffer(int width, int height)
        {
            double[,] zbuffer = new double[width, height];
            for (int x = 0; x < width; ++x)
                for (int y = 0; y < height; ++y)
                    zbuffer[x, y] = int.MinValue;
            return zbuffer;
        }

        public void scanLineFlat(Bitmap bmp, Objeto3D obj, int tx, int ty, Ponto3D Luz, Ponto3D Eye, int n,
            Ponto3D ia, Ponto3D id, Ponto3D ie, Ponto3D ka, Ponto3D kd, Ponto3D ke)
        {
            int height = bmp.Height, width = bmp.Width;

            double[,] zbuffer = gerarZBuffer(width, height);
            /// nova ET
            ET et;
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                obj.atualizaVetoresNormaisFaces();
                for (int i = 0; i < obj.getFaces().Count; ++i)
                {
                    if (obj.getVetNorFace(i).getZ() >= 0)
                    {
                        et = obj.gerarETFaceFlat(i, height, tx, ty, Luz, Eye, n, ia, id, ie, ka, kd, ke);
                        scanLineFaceFlat(data, et, zbuffer);//aqui
                    }
                }
            }
            bmp.UnlockBits(data);

        }

        private void scanLineFaceFlat(BitmapData data, ET et, double[,] zbuffer)
        {
            List<NoAET> lista;
            double z, inczx;
            int y = 0, cont = 0;
            while (y < et.getTF() && et.getAET(y) == null)
                ++y;
            AET aet = new AET(), aetAux;
            do // laço AET
            {
                if (et.getAET(y) != null)
                {
                    ++cont;
                    aet.add(et.getAET(y).getList()); 
                }
                aetAux = new AET();
                foreach (NoAET no in aet.getList())
                {
                    if (no.getYmax() > y)
                        aetAux.add(no);
                }
                aet = aetAux;
                aet.sort();
               
                lista = aet.getList();

       
                for (int i = 0, x, x2; i + 1 < lista.Count; i += 2)
                {
                    x = (int)Math.Round(lista[i].getXmin());             
                    x2 = (int)Math.Round(lista[i + 1].getXmin());
                    //Console.WriteLine(x+","+x2);
                    z = lista[i].getZmin();
                    inczx = (lista[i + 1].getZmin() - lista[i].getZmin()) / ((x2) - (x));
                    for (int c = x, c2 = (int)lista[i + 1].getXmin(); c <= c2; ++c)
                    {
                        if (inImage(data, x, y) && z > zbuffer[x, y]&&x>400&&x<1200)
                        {
                            zbuffer[x, y] = z;
                            writePixel(data, x, y, Color.FromArgb((int)lista[i].getRXmin(),
                                (int)lista[i].getGYmin(), (int)lista[i].getBZmin()));
                            //Console.WriteLine(x+","+y);
                        }
                        z += inczx;
                        ++x;
                        
                    }
                }
                for (int i = 0; i < aet.getList().Count; ++i)
                {
                    aet.getList()[i].setXmin(aet.getList()[i].getXmin() +
                        aet.getList()[i].getIncX());
                    aet.getList()[i].setZmin(aet.getList()[i].getZmin() + aet.getList()[i].getIncZY());
                }
                ++y;
            } while (aet.getList().Count > 0); 
        }
        
        


        private unsafe byte* gotoxy(BitmapData bmp, int x, int y)
        {
            byte* aux = (byte*)bmp.Scan0.ToPointer();
            aux += y * bmp.Stride; 
            aux += 3 * x; 
            return aux;
        }
        private unsafe byte* gotoxy(int x, int y, BitmapData bmp)
        {
            return gotoxy(bmp, x, y);
        }
        private unsafe void writePixel(BitmapData bmp, int x, int y, Color cor)
        {
            byte* aux = gotoxy(x, y, bmp);
            *aux = cor.B;
            *(aux + 1) = cor.G;
            *(aux + 2) = cor.R;
        }
        private unsafe void bresenham(BitmapData data, int x1, int y1, int x2, int y2,
            Color cor)
        {

            int dx = x2 - x1, x, y;
            int dy = y2 - y1;
            int declive = 1;

            int incE, incNE, d;
            if (abs(dx) > abs(dy))
            {
                if (x1 > x2)
                { 
                    bresenham(data, x2, y2, x1, y1, cor);
                    return;
                }
                if (y1 > y2)
                {  
                    declive = -1;
                    dy = -dy;
                }

                incE = 2 * dy;
                incNE = 2 * (dy - dx);
                d = incNE;

                y = y1;
                for (x = x1; x <= x2; ++x)
                {
                    if (inImage(data, x, y))
                        writePixel(data, x, y, cor);
                    if (d < 0) 
                        d += incE;
                    else
                    {   
                        d += incNE;
                        y += declive;
                    }
                }
            } 
            else
            { 
                if (y1 > y2)
                { 
                    bresenham(data, x2, y2, x1, y1, cor);
                    return;
                }
                if (x1 > x2)
                {   
                    declive = -1;
                    dx = -dx;
                }

                incE = 2 * dx;
                incNE = 2 * (dx - dy);
                d = incNE;

                x = x1;
                for (y = y1; y <= y2; ++y)
                {
                    if (inImage(data, x, y))
                        writePixel(data, x, y, cor);
                    if (d < 0) 
                        d += incE;
                    else
                    {   
                        d += incNE;
                        x += declive;
                    }
                }
            } 
        }
        public void floodFill(Bitmap bmp, int x, int y, Color cor)
        {
            Stack<int> pilha = new Stack<int>();
            // lock data
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                byte* aux = gotoxy(data, x, y);
                int fundoB = *aux, fundoG = *(aux + 1), fundoR = *(aux + 2);
                int[] dx = { -1, 0, 0, 1 };
                int[] dy = { 0, -1, 1, 0 };
                int i;
                pilha.Push(x);
                pilha.Push(y);
                while (pilha.Count > 0)
                {
                    y = pilha.Pop();
                    x = pilha.Pop();
                    aux = gotoxy(data, x, y);
                    *(aux++) = cor.B; 
                    *(aux++) = cor.G;
                    *aux = cor.R;
                    for (i = 0; i < 4; ++i)
                    {
                        if (inImage(data, x + dx[i], y + dy[i]))
                        {
                            aux = gotoxy(data, x + dx[i], y + dy[i]);
                            if (*aux == fundoB && *(aux + 1) == fundoG && *(aux + 2) == fundoR)
                            {
                                pilha.Push(x + dx[i]);
                                pilha.Push(y + dy[i]);
                            }
                        }
                    }
                }
            }


            bmp.UnlockBits(data);

        }
        private void swap(ref int a, ref int b)
        {
            a ^= b;
            b ^= a;
            a ^= b;
        }

        private bool inImage(BitmapData bmp, int x, int y)
        {
            return x >= 0 && x < bmp.Width && y >= 0 && y < bmp.Height;
        }

        public void paint(Bitmap bmp, Color cor)
        {

           
            BitmapData bmpdata = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                int height = bmp.Height;
                int width = bmp.Width;
                int padding = bmpdata.Stride - width * 3;
                byte* aux = (byte*)bmpdata.Scan0.ToPointer();
                for (int y = 0, x; y < height; ++y)
                {
                    for (x = 0; x < width; ++x)
                    {
                        *(aux++) = cor.B;
                        *(aux++) = cor.G;
                        *(aux++) = cor.R;
                    }
                    aux += padding;
                }
            }

            bmp.UnlockBits(bmpdata);
        }


        public void paintVistas(Bitmap bmpPlanta, Bitmap bmpFrontal, Bitmap bmpLateral, Color cor)
        {
            BitmapData dataP = bmpPlanta.LockBits(new Rectangle(0, 0, bmpPlanta.Width, bmpPlanta.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData dataF = bmpFrontal.LockBits(new Rectangle(0, 0, bmpFrontal.Width, bmpFrontal.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData dataL = bmpLateral.LockBits(new Rectangle(0, 0, bmpLateral.Width, bmpLateral.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                int height = bmpFrontal.Height;
                int width = bmpFrontal.Width;
                int padding = dataF.Stride - width * 3;
                byte* auxP = (byte*)dataP.Scan0.ToPointer(), auxF = (byte*)dataF.Scan0.ToPointer(),
                    auxL = (byte*)dataL.Scan0.ToPointer();
                for (int y = 0, x; y < height; ++y)
                {
                    for (x = 0; x < width; ++x)
                    {
                        *(auxP++) = *(auxF++) = *(auxL++) = cor.B;
                        *(auxP++) = *(auxF++) = *(auxL++) = cor.G;
                        *(auxP++) = *(auxF++) = *(auxL++) = cor.R;
                    }
                    auxP += padding;
                    auxF += padding;
                    auxL += padding;
                }
            }

            bmpPlanta.UnlockBits(dataL);
            bmpFrontal.UnlockBits(dataF);
            bmpLateral.UnlockBits(dataP);
        }

        public void writeObjeto3DObliqua(Bitmap bmp, Objeto3D obj, int tx, int ty, Color cor, bool rmFacesOcultas, double L)
        {
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                this.cx = tx;
                this.cy = ty;
                List<int> f;
                List<List<int>> faces = obj.getFaces();
                List<Ponto3D> vertices = obj.getVertices();
                if (rmFacesOcultas)
                {
                    for (int idf = 0; idf < faces.Count; ++idf)
                        if (obj.getVetNorFace(idf).getY() <= 0.0)
                            writeFaceObliquaXY(data, faces[idf], vertices, L, cor);
                }
                else
                    for (int idf = 0; idf < faces.Count; ++idf)
                        writeFaceObliquaXY(data, faces[idf], vertices, L, cor);
            }
            bmp.UnlockBits(data);
        }

        public void writeObjeto3DParalelaZX(Bitmap bmp, Objeto3D obj, Color corlinha, bool rmFacesOcultas)
        {
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                this.cx = bmp.Width >> 1;
                this.cy = bmp.Height >> 1;
                List<int> f;
                List<List<int>> faces = obj.getFaces();
                List<Ponto3D> vertices = obj.getVertices();
                if (rmFacesOcultas)
                {
                    for (int idf = 0; idf < faces.Count; ++idf)
                        if (obj.getVetNorFace(idf).getY() <= 0.0)
                            writeFaceParalelaZX(data, faces[idf], vertices, corlinha);
                }
                else
                    for (int idf = 0; idf < faces.Count; ++idf)
                        writeFaceParalelaZX(data, faces[idf], vertices, corlinha);
            }
            bmp.UnlockBits(data);
        }


        public void writeObjeto3DParalelaZY(Bitmap bmp, Objeto3D obj, Color corlinha, bool rmFacesOcultas)
        {
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                this.cx = bmp.Width >> 1;
                this.cy = bmp.Height >> 1;
                List<List<int>> faces = obj.getFaces();
                List<Ponto3D> vertices = obj.getVertices();
                if (rmFacesOcultas)
                {
                    for (int idf = 0; idf < faces.Count; ++idf)
                        if (obj.getVetNorFace(idf).getX() <= 0.0)
                            writeFaceParalelaZY(data, faces[idf], vertices, corlinha);
                }
                else
                    for (int idf = 0; idf < faces.Count; ++idf)
                        writeFaceParalelaZY(data, faces[idf], vertices, corlinha);

            }
            bmp.UnlockBits(data);
        }

        public void writeObjeto3DParalelaXY(Bitmap bmp, Objeto3D obj, int tx, int ty, Color corlinha, bool rmFacesOcultas)
        {
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                cx = tx;
                cy = ty;
                List<int> f;
                List<List<int>> faces = obj.getFaces();
                List<Ponto3D> vertices = obj.getVertices();
                if (rmFacesOcultas)
                {
                    for (int idf = 0; idf < faces.Count; ++idf)
                        if (obj.getVetNorFace(idf).getZ() >= 0.0)
                            writeFaceParalelaXY(data, faces[idf], vertices, corlinha);

                }
                else
                {
                    for (int idf = 0; idf < faces.Count; ++idf)
                        writeFaceParalelaXY(data, faces[idf], vertices, corlinha);
                }
            }
            bmp.UnlockBits(data);
        }

        private unsafe void writeFaceParalelaXY(BitmapData data, List<int> f, List<Ponto3D> vertices, Color cor)
        {

            Ponto3D p1, p2;
            int i;
            for (i = 0; i + 1 < f.Count; ++i)
            {
                p1 = vertices[f[i]];
                p2 = vertices[f[i + 1]];
                bresenham(data, (int)p1.getX() + cx, (int)p1.getY() + cy,
                    (int)p2.getX() + cx, (int)p2.getY() + cy, cor);
            }
            i = f.Count - 1;
            p1 = vertices[f[i]];
            p2 = vertices[f[0]];
            bresenham(data, (int)p1.getX() + cx, (int)p1.getY() + cy,
                (int)p2.getX() + cx, (int)p2.getY() + cy, cor);
        }

        private unsafe void writeFaceParalelaZY(BitmapData data, List<int> f, List<Ponto3D> vertices, Color cor)
        {

            Ponto3D p1, p2;
            int i;
            for (i = 0; i + 1 < f.Count; ++i)
            {
                p1 = vertices[f[i]];
                p2 = vertices[f[i + 1]];
                bresenham(data, (int)p1.getZ() + cx, (int)p1.getY() + cy,
                    (int)p2.getZ() + cx, (int)p2.getY() + cy, cor);
            }
            i = f.Count - 1;
            p1 = vertices[f[i]];
            p2 = vertices[f[0]];
            bresenham(data, (int)p1.getZ() + cx, (int)p1.getY() + cy,
                (int)p2.getZ() + cx, (int)p2.getY() + cy, cor);
        }

        private unsafe void writeFaceParalelaZX(BitmapData data, List<int> f, List<Ponto3D> vertices, Color cor)
        {
            Ponto3D p1, p2;
            int i;
            for (i = 0; i + 1 < f.Count; ++i)
            {
                p1 = vertices[f[i]];
                p2 = vertices[f[i + 1]];
                bresenham(data, (int)p1.getZ() + cx, (int)p1.getX() + cy,
                    (int)p2.getZ() + cx, (int)p2.getX() + cy, cor);
            }
            i = f.Count - 1;
            p1 = vertices[f[i]];
            p2 = vertices[f[0]];
            bresenham(data, (int)p1.getZ() + cx, (int)p1.getX() + cy,
                    (int)p2.getZ() + cx, (int)p2.getX() + cy, cor);
        }
        private unsafe void writeFaceObliquaXY(BitmapData data, List<int> f, List<Ponto3D> vertices, double L, Color cor)
        {
            Ponto3D p1, p2;
            int i, x1, y1, x2, y2;
            for (i = 0; i + 1 < f.Count; ++i)
            {
                p1 = vertices[f[i]];
                p2 = vertices[f[i + 1]];
                x1 = (int)(p1.getX() + p1.getZ() * L * Math.Cos(45 * Math.PI / 180));
                y1 = (int)(p1.getY() + p1.getZ() * L * Math.Sin(45 * Math.PI / 180));
                x2 = (int)(p2.getX() + p2.getZ() * L * Math.Cos(45 * Math.PI / 180));
                y2 = (int)(p2.getY() + p2.getZ() * L * Math.Sin(45 * Math.PI / 180));
                bresenham(data, x1 + cx, y1 + cy, x2 + cx, y2 + cy, cor);
            }
            i = f.Count - 1;
            p1 = vertices[f[i]];
            p2 = vertices[f[0]];
            x1 = (int)(p1.getX() + p1.getZ() * L * Math.Cos(45 * Math.PI / 180));
            y1 = (int)(p1.getY() + p1.getZ() * L * Math.Sin(45 * Math.PI / 180));
            x2 = (int)(p2.getX() + p2.getZ() * L * Math.Cos(45 * Math.PI / 180));
            y2 = (int)(p2.getY() + p2.getZ() * L * Math.Sin(45 * Math.PI / 180));
            bresenham(data, x1 + cx, y1 + cy, x2 + cx, y2 + cy, cor);
        }

        public void writeObjeto3DPerspectivaXY(Bitmap bmp, Objeto3D obj, int tx, int ty, Color corlinha, bool rmFacesOcultas, double d)
        {
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                int idf;
                this.cx = tx;
                this.cy = ty;
                List<List<int>> faces = obj.getFaces();
                List<Ponto3D> vertices = obj.getVertices();
                if (rmFacesOcultas)
                {
                    for (idf = 0; idf < faces.Count; ++idf)
                        if (obj.getVetNorFace(idf).getZ() > 0.0)
                            writeFacePerspectivaXY(data, faces[idf], vertices, d, corlinha);
                }
                else
                    for (idf = 0; idf < faces.Count; ++idf)
                        writeFacePerspectivaXY(data, faces[idf], vertices, d, corlinha);
            }
            bmp.UnlockBits(data);
        }

        public void writeObjeto3DPerspectivaZY(Bitmap bmp, Objeto3D obj, Color corlinha, bool rmFacesOcultas, double d)
        {
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                int idf;
                this.cx = bmp.Width >> 1;
                this.cy = bmp.Height >> 1;
                List<List<int>> faces = obj.getFaces();
                List<Ponto3D> vertices = obj.getVertices();
                if (rmFacesOcultas)
                {
                    for (idf = 0; idf < faces.Count; ++idf)
                        if (obj.getVetNorFace(idf).getX() > 0.0)
                            writeFacePerspectivaZY(data, faces[idf], vertices, d, corlinha);
                }
                else
                    for (idf = 0; idf < faces.Count; ++idf)
                        writeFacePerspectivaZY(data, faces[idf], vertices, d, corlinha);
            }
            bmp.UnlockBits(data);
        }

        public void writeObjeto3DPerspectivaZX(Bitmap bmp, Objeto3D obj, Color corlinha, bool rmFacesOcultas, double d)
        {
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                int idf;
                this.cx = bmp.Width >> 1;
                this.cy = bmp.Height >> 1;
                List<List<int>> faces = obj.getFaces();
                List<Ponto3D> vertices = obj.getVertices();
                if (rmFacesOcultas)
                {
                    for (idf = 0; idf < faces.Count; ++idf)
                        if (obj.getVetNorFace(idf).getY() >= 0.0)
                            writeFacePerspectivaZX(data, faces[idf], vertices, d, corlinha);
                }
                else
                    for (idf = 0; idf < faces.Count; ++idf)
                        writeFacePerspectivaZX(data, faces[idf], vertices, d, corlinha);
            }
            bmp.UnlockBits(data);
        }

        private unsafe void writeFacePerspectivaXY(BitmapData data, List<int> f, List<Ponto3D> vertices, double d, Color cor)
        {
            Ponto3D p1, p2;
            int i;
            double x1, y1, z1, x2, y2, z2;
            for (i = 0; i + 1 < f.Count; ++i)
            {
                p1 = vertices[f[i]];
                p2 = vertices[f[i + 1]];
                x1 = p1.getX(); y1 = p1.getY(); z1 = p1.getZ();
                x2 = p2.getX(); y2 = p2.getY(); z2 = p2.getZ();
                x1 = x1 * d / (z1 += d);
                y1 = y1 * d / z1;
                x2 = x2 * d / (z2 += d);
                y2 = y2 * d / z2;
                bresenham(data, (int)x1 + cx, (int)y1 + cy,
                    (int)x2 + cx, (int)y2 + cy, cor);
            }
            i = f.Count - 1;
            p1 = vertices[f[i]];
            p2 = vertices[f[0]];
            x1 = p1.getX(); y1 = p1.getY(); z1 = p1.getZ();
            x2 = p2.getX(); y2 = p2.getY(); z2 = p2.getZ();
            x1 = x1 * d / (z1 += d);
            y1 = y1 * d / z1;
            x2 = x2 * d / (z2 += d);
            y2 = y2 * d / z2;
            bresenham(data, (int)x1 + cx, (int)y1 + cy,
                (int)x2 + cx, (int)y2 + cy, cor);
        }

        private unsafe void writeFacePerspectivaZX(BitmapData data, List<int> f, List<Ponto3D> vertices, double d, Color cor)
        {
            Ponto3D p1, p2;
            int i;
            double x1, y1, z1, x2, y2, z2;
            for (i = 0; i + 1 < f.Count; ++i)
            {
                p1 = vertices[f[i]];
                p2 = vertices[f[i + 1]];
                x1 = p1.getZ(); y1 = p1.getX(); z1 = p1.getY();
                x2 = p2.getZ(); y2 = p2.getX(); z2 = p2.getY();
                x1 = x1 * d / (z1 += d);
                y1 = y1 * d / z1;
                x2 = x2 * d / (z2 += d);
                y2 = y2 * d / z2;
                bresenham(data, (int)x1 + cx, (int)y1 + cy,
                    (int)x2 + cx, (int)y2 + cy, cor);
            }
            i = f.Count - 1;
            p1 = vertices[f[i]];
            p2 = vertices[f[0]];
            x1 = p1.getZ(); y1 = p1.getX(); z1 = p1.getY();
            x2 = p2.getZ(); y2 = p2.getX(); z2 = p2.getY();
            x1 = x1 * d / (z1 += d);
            y1 = y1 * d / z1;
            x2 = x2 * d / (z2 += d);
            y2 = y2 * d / z2;
            bresenham(data, (int)x1 + cx, (int)y1 + cy,
                (int)x2 + cx, (int)y2 + cy, cor);
        }

        private unsafe void writeFacePerspectivaZY(BitmapData data, List<int> f, List<Ponto3D> vertices, double d, Color cor)
        {
            Ponto3D p1, p2;
            int i;
            double x1, y1, z1, x2, y2, z2;

            for (i = 0; i + 1 < f.Count; ++i)
            {
                p1 = vertices[f[i]];
                p2 = vertices[f[i + 1]];
                x1 = p1.getZ(); y1 = p1.getY(); z1 = p1.getX();
                x2 = p2.getZ(); y2 = p2.getY(); z2 = p2.getX();
                x1 = x1 * d / (z1 += d);
                y1 = y1 * d / z1;
                x2 = x2 * d / (z2 += d);
                y2 = y2 * d / z2;
                bresenham(data, (int)x1 + cx, (int)y1 + cy,
                    (int)x2 + cx, (int)y2 + cy, cor);
            }
            i = f.Count - 1;
            p1 = vertices[f[i]];
            p2 = vertices[f[0]];
            x1 = p1.getZ(); y1 = p1.getY(); z1 = p1.getX();
            x2 = p2.getZ(); y2 = p2.getY(); z2 = p2.getX();
            x1 = x1 * d / (z1 += d);
            y1 = y1 * d / z1;
            x2 = x2 * d / (z2 += d);
            y2 = y2 * d / z2;
            bresenham(data, (int)x1 + cx, (int)y1 + cy,
                (int)x2 + cx, (int)y2 + cy, cor);

        }

        public void writeVistasParalela(Bitmap bmpPlanta, Bitmap bmpFrontal, Bitmap bmpLateral, Objeto3D obj, Color cor, bool rmFocultas)
        {
            BitmapData dataP = bmpPlanta.LockBits(new Rectangle(0, 0, bmpPlanta.Width, bmpPlanta.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData dataF = bmpFrontal.LockBits(new Rectangle(0, 0, bmpFrontal.Width, bmpFrontal.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData dataL = bmpLateral.LockBits(new Rectangle(0, 0, bmpLateral.Width, bmpLateral.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                int idf;
                this.cx = bmpFrontal.Width >> 1;
                this.cy = bmpFrontal.Height >> 1;
                List<List<int>> faces = obj.getFaces();
                List<Ponto3D> vertices = obj.getVertices();
                if (rmFocultas)
                {
                    for (idf = 0; idf < faces.Count; ++idf)
                    {
                        if (obj.getVetNorFace(idf).getY() >= 0.0)
                            writeFaceParalelaZX(dataP, faces[idf], vertices, cor);
                        if (obj.getVetNorFace(idf).getZ() >= 0.0)
                            writeFaceParalelaXY(dataF, faces[idf], vertices, cor);
                        if (obj.getVetNorFace(idf).getX() >= 0.0)
                            writeFaceParalelaZY(dataL, faces[idf], vertices, cor);
                    }

                }
                else
                    for (idf = 0; idf < faces.Count; ++idf) 
                        writeFacesVistasParalela(dataP, dataF, dataL, faces[idf], vertices, cor);
            }
            bmpPlanta.UnlockBits(dataL);
            bmpFrontal.UnlockBits(dataF);
            bmpLateral.UnlockBits(dataP);
        }

        private unsafe void writeFacesVistasParalela(BitmapData dataP, BitmapData dataF, BitmapData dataL,
            List<int> f, List<Ponto3D> vertices, Color cor)
        {
            Ponto3D p1, p2;
            int i;
            for (i = 0; i + 1 < f.Count; ++i)
            {
                p1 = vertices[f[i]];
                p2 = vertices[f[i + 1]];

                bresenham(dataP, (int)p1.getZ() + cx, (int)p1.getX() + cy,
                    (int)p2.getZ() + cx, (int)p2.getX() + cy, cor);

                bresenham(dataF, (int)p1.getX() + cx, (int)p1.getY() + cy,
                    (int)p2.getX() + cx, (int)p2.getY() + cy, cor);

                bresenham(dataL, (int)p1.getZ() + cx, (int)p1.getY() + cy,
                    (int)p2.getZ() + cx, (int)p2.getY() + cy, cor);
            }
            i = f.Count - 1;
            p1 = vertices[f[i]];
            p2 = vertices[f[0]];
            bresenham(dataP, (int)p1.getZ() + cx, (int)p1.getX() + cy,
                (int)p2.getZ() + cx, (int)p2.getX() + cy, cor);
            bresenham(dataF, (int)p1.getX() + cx, (int)p1.getY() + cy,
                (int)p2.getX() + cx, (int)p2.getY() + cy, cor);
            bresenham(dataL, (int)p1.getZ() + cx, (int)p1.getY() + cy,
                (int)p2.getZ() + cx, (int)p2.getY() + cy, cor);
        }

        public void writeVistasPerspectiva(Bitmap bmpPlanta, Bitmap bmpFrontal, Bitmap bmpLateral, Objeto3D obj, double d, bool rmFocultas, Color cor)
        {
            BitmapData dataP = bmpPlanta.LockBits(new Rectangle(0, 0, bmpPlanta.Width, bmpPlanta.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData dataF = bmpFrontal.LockBits(new Rectangle(0, 0, bmpFrontal.Width, bmpFrontal.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData dataL = bmpLateral.LockBits(new Rectangle(0, 0, bmpLateral.Width, bmpLateral.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                int idf;
                this.cx = bmpFrontal.Width >> 1;
                this.cy = bmpFrontal.Height >> 1;
                List<List<int>> faces = obj.getFaces();
                List<Ponto3D> vertices = obj.getVertices();
                if (rmFocultas)
                {
                    for (idf = 0; idf < faces.Count; ++idf)
                    {
                        if (obj.getVetNorFace(idf).getY() >= 0.0)
                            writeFacePerspectivaZX(dataP, faces[idf], vertices, d, cor);
                        if (obj.getVetNorFace(idf).getZ() >= 0.0)
                            writeFacePerspectivaXY(dataF, faces[idf], vertices, d, cor);
                        if (obj.getVetNorFace(idf).getY() >= 0.0)
                            writeFacePerspectivaZY(dataL, faces[idf], vertices, d, cor);
                    }

                }
                else
                    for (idf = 0; idf < faces.Count; ++idf)
                    {
                        writeFacePerspectivaZX(dataP, faces[idf], vertices, d, cor);
                        writeFacePerspectivaXY(dataF, faces[idf], vertices, d, cor);
                        writeFacePerspectivaZY(dataL, faces[idf], vertices, d, cor);
                    }
            }
            bmpPlanta.UnlockBits(dataL);
            bmpPlanta.UnlockBits(dataF);
            bmpPlanta.UnlockBits(dataP);
        }

        public void writeLineBresenham(Bitmap bmp, int x1, int y1, int x2, int y2, Color cor)
        {   
            BitmapData bmpdata = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {

                bresenham(bmpdata, x1, y1, x2, y2, cor);
            }

            bmp.UnlockBits(bmpdata);
        }

        public void scanLineGouraud(Bitmap bmp, Objeto3D obj, int tx, int ty, Ponto3D Luz, Ponto3D Eye, int n,
           Ponto3D ia, Ponto3D id, Ponto3D ie, Ponto3D ka, Ponto3D kd, Ponto3D ke)
        {
            int height = bmp.Height, width = bmp.Width;

            double[,] zbuffer = gerarZBuffer(width, height);
            /// gerando ET
            ET et;

            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                obj.atualizaVetoresNormaisFaces();
                obj.atualizaVetoresNormaisVertices();
                for (int i = 0; i < obj.getFaces().Count; ++i)
                {
                    if (obj.getVetNorFace(i).getZ() >= 0)
                    {
                        et = obj.gerarETFaceGouraud(i, height, tx, ty, Luz, Eye, n, ia, id, ie, ka, kd, ke);
                        scanLineFaceGouraud(data, et, zbuffer);
                    }
                }
            }
            bmp.UnlockBits(data);

        }
        private void scanLineFaceGouraud(BitmapData data, ET et, double[,] zbuffer)
        {
            List<NoAET> lista;
            double z, inczx;
            int y = 0;
            AET aet = new AET(), aetAux;
            while (y < et.getTF() && et.getAET(y) == null)
                ++y;
            do // laço AET
            {
                if (et.getAET(y) != null)
                    aet.add(et.getAET(y).getList()); // adicionando novos nodos
                                                     // removendo nodos com Ymax == Y
                aetAux = new AET();
                foreach (NoAET no in aet.getList())
                {
                    if (no.getYmax() > y)
                        aetAux.add(no);
                }
                aet = aetAux;
                aet.sort();
                // desenhando linhas
                lista = aet.getList();
                for (int i = 0, x, x2; i + 1 < lista.Count; i += 2)
                {
                    x = (int)Math.Round(lista[i].getXmin());
                    x2 = (int)Math.Round(lista[i + 1].getXmin());
                    z = lista[i].getZmin();
                    double r, g, b, incrx, incgx, incbx, dx = x2 - x;
                    r = lista[i].getRXmin();
                    g = lista[i].getGYmin();
                    b = lista[i].getBZmin();
                    incrx = (lista[i + 1].getRXmin() - lista[i].getRXmin()) / dx;
                    incgx = (lista[i + 1].getGYmin() - lista[i].getGYmin()) / dx;
                    incbx = (lista[i + 1].getBZmin() - lista[i].getBZmin()) / dx;

                    inczx = (lista[i + 1].getZmin() - lista[i].getZmin()) / dx;
                    while (x <= x2)
                    {
                        if (inImage(data, x, y) && z > zbuffer[x, y])
                        {
                            zbuffer[x, y] = z;
                            writePixel(data, x, y, Color.FromArgb((int)r, (int)g, (int)b));
                        }
                        r += incrx;
                        g += incgx;
                        b += incbx;
                        z += inczx;
                        ++x;
                    }
                }
                foreach (NoAET no in aet.getList())
                {
                    no.setXmin(no.getXmin() + no.getIncX());
                    no.setZmin(no.getZmin() + no.getIncZY());
                    no.setRXmin(no.getRXmin() + no.getIncRX());
                    no.setGYmin(no.getGYmin() + no.getIncGY());
                    no.setBZmin(no.getBZmin() + no.getIncBZ());
                }
                ++y;
            } while (aet.getList().Count > 0); // tem pontos na AET
        }

        public void scanLinePhong(Bitmap bmp, Objeto3D obj, int tx, int ty, Ponto3D Luz, Ponto3D Eye, int n,
            Ponto3D ia, Ponto3D id, Ponto3D ie, Ponto3D ka, Ponto3D kd, Ponto3D ke)
        {
            int height = bmp.Height, width = bmp.Width;
            double[,] zbuffer = gerarZBuffer(width, height);
            ET et;

            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            unsafe
            {
                obj.atualizaVetoresNormaisFaces();
                obj.atualizaVetoresNormaisVertices();
                for (int i = 0; i < obj.getFaces().Count; ++i)
                {
                    if (obj.getVetNorFace(i).getZ() >= 0)
                    {
                        et = obj.gerarETFacePhong(i, height, tx, ty, Luz, Eye, n, ia, id, ie, ka, kd, ke);
                        scanLineFacePhong(data, et, zbuffer, Luz, Eye, n, ia, id, ie, ka, kd, ke);
                    }
                }
            }
            bmp.UnlockBits(data);

        }

        private void scanLineFacePhong(BitmapData data, ET et, double[,] zbuffer, Ponto3D Luz, Ponto3D Eye, int n,
            Ponto3D ia, Ponto3D id, Ponto3D ie, Ponto3D ka, Ponto3D kd, Ponto3D ke)
        {
            List<NoAET> lista;
            double z, inczx;
            int y = 0;
            Ponto3D cor;
            AET aet = new AET(), aetAux;
            while (y < et.getTF() && et.getAET(y) == null)
                ++y;
            do // laço AET
            {
                if (et.getAET(y) != null)
                    aet.add(et.getAET(y).getList()); // adicionando novos nodos
                                                     // removendo nodos com Ymax == Y
                aetAux = new AET();
                foreach (NoAET no in aet.getList())
                {
                    if (no.getYmax() > y)
                        aetAux.add(no);
                }
                aet = aetAux;
                aet.sort();
                // desenhando linhas
                lista = aet.getList();
                for (int i = 0, x, x2; i + 1 < lista.Count; i += 2)
                {
                    x = (int)Math.Round(lista[i].getXmin());
                    x2 = (int)Math.Round(lista[i + 1].getXmin());
                    z = lista[i].getZmin();
                    double r, g, b, incrx, incgx, incbx, dx = x2 - x;
                    r = lista[i].getRXmin();
                    g = lista[i].getGYmin();
                    b = lista[i].getBZmin();
                    incrx = (lista[i + 1].getRXmin() - lista[i].getRXmin()) / dx;
                    incgx = (lista[i + 1].getGYmin() - lista[i].getGYmin()) / dx;
                    incbx = (lista[i + 1].getBZmin() - lista[i].getBZmin()) / dx;

                    inczx = (lista[i + 1].getZmin() - lista[i].getZmin()) / dx;
                    while (x <= x2)
                    {
                        if (inImage(data, x, y) && z > zbuffer[x, y])
                        {
                            cor = corPhong(Luz, Eye, new Ponto3D(r, g, b), n, ia, id, ie, ka, kd, ke);
                            zbuffer[x, y] = z;
                            writePixel(data, x, y, Color.FromArgb((int)cor.getX(), (int)cor.getY(), (int)cor.getZ()));
                        }
                        r += incrx;
                        g += incgx;
                        b += incbx;
                        z += inczx;
                        ++x;
                    }
                }
                foreach (NoAET no in aet.getList())
                {
                    no.setXmin(no.getXmin() + no.getIncX());
                    no.setZmin(no.getZmin() + no.getIncZY());
                    no.setRXmin(no.getRXmin() + no.getIncRX());
                    no.setGYmin(no.getGYmin() + no.getIncGY());
                    no.setBZmin(no.getBZmin() + no.getIncBZ());
                }
                ++y;
            } while (aet.getList().Count > 0); // tem pontos na AET
        }
    }
}
