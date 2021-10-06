using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Visualizador3D.extra;

namespace Visualizador3D
{
    public partial class Form1 : Form
    {
        private static bool ctrlPress;
        private Bitmap bmpPrincipal, bmpPlanta, bmpFrontal, bmpLateral;
        private Desenha draw;
        private Random random;
        private Objeto3D obj;
        private int x1, y1, x2, y2, tx, ty;
        private bool mvluz = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            pbPrincipal.Enabled = false;
            cbProjecao.SelectedIndex = 0;
            draw = new Desenha();
            new Thread(() =>
            {
                Thread.Sleep(200);
                bmpPrincipal = new Bitmap(pbPrincipal.Width, pbPrincipal.Height);
                bmpPlanta = new Bitmap(pbPlanta.Width, pbPlanta.Height);
                bmpFrontal = new Bitmap(pbPlanta.Width, pbPlanta.Height);
                bmpLateral = new Bitmap(pbPlanta.Width, pbPlanta.Height);
                draw.paint(bmpPrincipal, lbCAmb.BackColor);
                draw.paint(bmpPlanta, lbCAmb.BackColor);
                draw.paint(bmpFrontal, lbCAmb.BackColor);
                draw.paint(bmpLateral, lbCAmb.BackColor);
                this.Invoke(new MethodInvoker(delegate ()
                {
                    pbPrincipal.Image = bmpPrincipal;
                    pbPlanta.Image = bmpPlanta;
                    pbFrontal.Image = bmpFrontal;
                    pbLateral.Image = bmpLateral;
                    // intensidade
                    ia = new Ponto3D(0, 0, 0);
                    id = new Ponto3D(0, 0, 0.9);
                    sbIMatB.Value = (int)(0.9 * 91);
                    atualizaCorLabel(lbIMat, id);
                    ie = new Ponto3D(0.7, 0.7, 0.7);
                    sbIBrilhoR.Value = (int)(0.7 * 91);
                    sbIBrilhoG.Value = (int)(0.7 * 91);
                    sbIBrilhoB.Value = (int)(0.7 * 91);
                    atualizaCorLabel(lbIBrilho, ie);
                    // cor
                    ka = new Ponto3D(0.2, 0.2, 0.2);
                    sbCAmbR.Value = (int)(0.2 * 91);
                    sbCAmbG.Value = (int)(0.2 * 91);
                    sbCAmbB.Value = (int)(0.2 * 91);
                    atualizaCorLabel(lbCAmb, ka);
                    kd = new Ponto3D(0, 0, 0.5);
                    sbCMatB.Value = (int)(0.5 * 91);
                    atualizaCorLabel(lbCMat, kd);
                    ke = new Ponto3D(0.8, 0.8, 0.8);
                    sbCBrilhoR.Value = (int)(0.8 * 91);
                    sbCBrilhoG.Value = (int)(0.8 * 91);
                    sbCBrilhoB.Value = (int)(0.8 * 91);
                    atualizaCorLabel(lbCBrilho, ke);
                    Eye = new Ponto3D(0, 0, 1);
                    Luz = new Ponto3D(-1, -1, 1);
                    tx = bmpPrincipal.Width >> 1;
                    ty = bmpPrincipal.Height >> 1;
                }));
            }).Start();
        }

        private string txd = "0";
        private Ponto3D ia, id, ie, ka, kd, ke, Eye, Luz;

        private void sbIAmbG_Scroll(object sender, ScrollEventArgs e)
        {
            ia.setY(sbIAmbG.Value / 91.0);
            atualizaCorLabel(lbIAmb, ia);
        }

        private void sbIAmbB_Scroll(object sender, ScrollEventArgs e)
        {
            ia.setZ(sbIAmbB.Value / 91.0);
            atualizaCorLabel(lbIAmb, ia);
        }

        private void sbIMatR_Scroll(object sender, ScrollEventArgs e)
        {
            id.setX(sbIMatR.Value / 91.0);
            atualizaCorLabel(lbIMat, id);
        }

        private void sbIMatG_Scroll(object sender, ScrollEventArgs e)
        {
            id.setX(sbIMatG.Value / 91.0);
            atualizaCorLabel(lbIMat, id);
        }

        private void sbIMatB_Scroll(object sender, ScrollEventArgs e)
        {
            id.setX(sbIMatB.Value / 91.0);
            atualizaCorLabel(lbIMat, id);
        }

        private void sbIBrilhoR_Scroll(object sender, ScrollEventArgs e)
        {
            ie.setX(sbIBrilhoR.Value / 91.0);
            atualizaCorLabel(lbIBrilho, ie);
        }

        private void sbIBrilhoG_Scroll(object sender, ScrollEventArgs e)
        {
            ie.setX(sbIBrilhoG.Value / 91.0);
            atualizaCorLabel(lbIBrilho, ie);
        }

        private void sbIBrilhoB_Scroll(object sender, ScrollEventArgs e)
        {
            ie.setX(sbIBrilhoB.Value / 91.0);
            atualizaCorLabel(lbIBrilho, ie);
        }

        private void sbCAmbR_Scroll(object sender, ScrollEventArgs e)
        {
            ka.setX(sbCAmbR.Value / 91.0);
            atualizaCorLabel(lbCAmb, ka);
        }

        private void sbCAmbG_Scroll(object sender, ScrollEventArgs e)
        {
            ka.setX(sbCAmbG.Value / 91.0);
            atualizaCorLabel(lbCAmb, ka);
        }

        private void sbCAmbB_Scroll(object sender, ScrollEventArgs e)
        {
            ka.setX(sbCAmbB.Value / 91.0);
            atualizaCorLabel(lbCAmb, ka);
        }

        private void sbCMatR_Scroll(object sender, ScrollEventArgs e)
        {
            kd.setX(sbCMatR.Value / 91.0);
            atualizaCorLabel(lbCMat, kd);
        }

        private void sbCMatG_Scroll(object sender, ScrollEventArgs e)
        {
            kd.setX(sbCMatG.Value / 91.0);
            atualizaCorLabel(lbCMat, kd);
        }

        private void sbCMatB_Scroll(object sender, ScrollEventArgs e)
        {
            kd.setX(sbCMatB.Value / 91.0);
            atualizaCorLabel(lbCMat, kd);
        }

        private void sbCBrilhoR_Scroll(object sender, ScrollEventArgs e)
        {
            ke.setX(sbCBrilhoR.Value / 91.0);
            atualizaCorLabel(lbCBrilho, ke);
        }

        private void sbCBrilhoG_Scroll(object sender, ScrollEventArgs e)
        {
            ke.setX(sbCBrilhoG.Value / 91.0);
            atualizaCorLabel(lbCBrilho, ke);
        }

        private void sbCBrilhoB_Scroll(object sender, ScrollEventArgs e)
        {
            ke.setX(sbCBrilhoB.Value / 91.0);
            atualizaCorLabel(lbCBrilho, ke);
        }

        private void rbWireframe_CheckedChanged(object sender, EventArgs e)
        {
            refreshObjeto();
        }

        private void rbFlat_CheckedChanged(object sender, EventArgs e)
        {
            refreshObjeto();
        }

        private void rbGouraud_CheckedChanged(object sender, EventArgs e)
        {
            refreshObjeto();    
        }

        private void rbPhong_CheckedChanged(object sender, EventArgs e)
        {
            refreshObjeto();
        }

        private void txN_ValueChanged(object sender, EventArgs e)
        {
            refreshObjeto();
        }

        private void ckFacesOcultas_CheckedChanged(object sender, EventArgs e)
        {
            refreshObjeto();
        }

        private void cbProjecao_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string proj = cbProjecao.Text;
            tbD.Enabled = proj == "Perspectiva";
            refreshObjeto();
        }

        private void tbD_TextChanged(object sender, EventArgs e)
        {
            tbD.Text = tbD.Text.Trim();
            if (tbD.Text.Length == 0)
                txd = "0";
            double d;
            if (double.TryParse(tbD.Text, out d))
                txd = tbD.Text;
            tbD.Text = txd;
        }

        private void sbIAmbR_Scroll(object sender, ScrollEventArgs e)
        {
            ia.setX(sbIAmbR.Value / 91.0);
            atualizaCorLabel(lbIAmb, ia);
        }

        private void btLuz_MouseMove(object sender, MouseEventArgs e)
        {
            if (mvluz)
            {
                atualizaBotaoLuz(MousePosition.X - (btLuz.Width >> 1), MousePosition.Y - btLuz.Height);
                refreshObjeto();
            }
        }

        private void btLuz_MouseUp(object sender, MouseEventArgs e)
        {
            if (mvluz)
                atualizaBotaoLuz(MousePosition.X - (btLuz.Width >> 1), MousePosition.Y - btLuz.Height);
            mvluz = false;
        }

        private void btLuz_MouseDown(object sender, MouseEventArgs e)
        {
            mvluz = obj != null && e.Button == MouseButtons.Left;
            if (mvluz)
                atualizaBotaoLuz(MousePosition.X - (btLuz.Width >> 1), MousePosition.Y - btLuz.Height);
        }

        private double graus2Radianos(double g)
        {
            return g * Math.PI / 180;
        }
        private void pbPrincipal_MouseMove(object sender, MouseEventArgs e)
        {
            x2 = e.X;
            y2 = e.Y;
            if (e.Button == MouseButtons.Left)
            { 
                if (ctrlPress)
                {
                    double g = (Math.Abs(y2 - y1) > Math.Abs(x2 - x1)) ? -(y2 - y1) : x2 - x1;
                    obj.rotacaoZ(graus2Radianos(g), ckFacesOcultas.Checked);
                }
                else
                {
                    obj.rotacaoX(graus2Radianos(-(y2 - y1)), ckFacesOcultas.Checked);
                    obj.rotacaoY(graus2Radianos(x2 - x1), ckFacesOcultas.Checked);
                }
                refreshObjeto();
            }
            else if (e.Button == MouseButtons.Right)
            { 
                tx += x2 - x1;
                ty += y2 - y1;
                refreshObjeto();
            }
            else if (e.Button == MouseButtons.Middle) 
            {
                double g = (Math.Abs(y2 - y1) > Math.Abs(x2 - x1)) ? -(y2 - y1) : x2 - x1;
                obj.rotacaoZ(graus2Radianos(g), ckFacesOcultas.Checked);
                refreshObjeto();
            }
            x1 = x2;
            y1 = y2;
        }

        private void pbPrincipal_MouseDown(object sender, MouseEventArgs e)
        {
             x1 = e.X;
             y1 = e.Y;
            
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btAbrir_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";
            openFileDialog.Filter = "objetos3D (*.obj)|*.obj";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tx = pbPrincipal.Width-465 >> 1; //-465
                ty = pbPrincipal.Height >> 1;
                obj = new Objeto3D(openFileDialog.FileName);
                double s = ((pbPrincipal.Width) >> 2) / Math.Abs(obj.getMaxX() - obj.getMinX());
                obj.escala(s, s, s);
                refreshObjeto();
                pbPrincipal.Enabled = true;
            }
        }
        private void atualizaCorLabel(Label lb, Ponto3D vc)
        {
            int c; Color cor;
            lb.BackColor = cor = Color.FromArgb((int)(vc.getX() * 255), (int)(vc.getY() * 255), (int)(vc.getZ() * 255));
            lb.ForeColor = Color.FromArgb(c = getContraste(cor.R, cor.G, cor.B), c, c);
            refreshObjeto();
        }

        private int getContraste(int r, int g, int b)
        {
            return (0.3 * r + 0.59 * g + 0.11 * b) > 120 ? 0 : 255;
        }

        private void w(string s)
        {
            Console.WriteLine(s);
        }
        private void atualizaBotaoLuz(int x, int y)
        {
            if (x < pbPrincipal.Location.X)
                x = pbPrincipal.Location.X;
            else if (x > (pbPrincipal.Location.X + pbPrincipal.Width) - btLuz.Width)
                x = (pbPrincipal.Location.X + pbPrincipal.Width) - btLuz.Width;
            if (y < pbPrincipal.Location.Y)
                y = pbPrincipal.Location.Y;
            else if (y > (pbPrincipal.Location.Y + pbPrincipal.Height) - btLuz.Height)
                y = (pbPrincipal.Location.Y + pbPrincipal.Height) - btLuz.Height;

            btLuz.Location = new Point(x, y);
            x = x + (btLuz.Width >> 1) - pbPrincipal.Location.X;
            y = y + (btLuz.Height >> 1) - pbPrincipal.Location.Y;

            w("Posicao: Luz: " + x + ", " + y + "; Obj: " + (obj.getCentro().getX() + tx) + ", " + (obj.getCentro().getY() + ty));
            Luz = new Ponto3D(x - (obj.getCentro().getX() + tx), y - (obj.getCentro().getY() + ty), 1);
            w("Luz : " + Luz.getX() + ", " + Luz.getY() + ", " + Luz.getZ());
            Luz = Luz.normalizar();
            Luz.setZ(1);
            w("Luz : " + Luz.getX() + ", " + Luz.getY() + ", " + Luz.getZ());
            btLuz.Refresh();
        }
        private void cbProjecao_SelectedIndexChanged(object sender, EventArgs e)
        {
            string proj = cbProjecao.Text;
            tbD.Enabled = proj == "Perspectiva";
            refreshObjeto();
        }



        private void refreshObjeto()
        {

            if (obj != null)
            {
                atualizaBotaoLuz(btLuz.Location.X, btLuz.Location.Y);
                double d;
                string proj = cbProjecao.SelectedItem.ToString().ToLower();
                double.TryParse(tbD.Text, out d);
                draw.paint(bmpPrincipal, lbCAmb.BackColor);
                if (cbProjecao.Text == "Perspectiva")
                {
                    draw.writeObjeto3DPerspectivaXY(bmpPrincipal, obj, tx, ty, lbCMat.BackColor, ckFacesOcultas.Checked, (d = double.Parse(tbD.Text)));
                    pbPrincipal.Refresh();
                    if (tcPrincipal.SelectedTab == tpVistas)
                    {
                        {
                            double s = (double)pbLateral.Width / pbPrincipal.Width;
                            Objeto3D obj2 = obj.getCopia();
                            obj2.escala(s, s, s);
                            // planta
                            draw.paint(bmpPlanta, lbCAmb.BackColor);
                            draw.writeObjeto3DPerspectivaZX(bmpPlanta, obj2, lbCMat.BackColor, ckFacesOcultas.Checked, d);
                            //frontal
                            draw.paint(bmpFrontal, lbCAmb.BackColor);
                            draw.writeObjeto3DPerspectivaXY(bmpFrontal, obj2, bmpFrontal.Width >> 1, bmpFrontal.Height >> 1,
                                lbCMat.BackColor, ckFacesOcultas.Checked, d);
                            //lateral
                            draw.paint(bmpLateral, lbCAmb.BackColor);
                            draw.writeObjeto3DPerspectivaZY(bmpLateral, obj2, lbCMat.BackColor, ckFacesOcultas.Checked, d);
                            pbPlanta.Refresh();
                            pbFrontal.Refresh();
                            pbLateral.Refresh();
                        }

                    }
                }
                else if (cbProjecao.Text[0] == 'C')
                {
                    // Cavaleira: L = 1;
                    // Cabinet: L = 0.5;
                    double L;
                    L = cbProjecao.Text[2] == 'v' ? 1 : 0.5;
                    draw.writeObjeto3DObliqua(bmpPrincipal, obj, tx, ty, lbCMat.BackColor, ckFacesOcultas.Checked, L);
                    pbPrincipal.Refresh();
                    if (tcPrincipal.SelectedTab == tpVistas)
                    {

                    }
                }
                else
                { // Paralela
                    if (rbWireframe.Checked)
                        draw.writeObjeto3DParalelaXY(bmpPrincipal, obj, tx, ty, lbCMat.BackColor, ckFacesOcultas.Checked);
                    else
                    {
                        if (rbFlat.Checked)//flat
                        {
                            draw.scanLineFlat(bmpPrincipal, obj, tx, ty, Luz, Eye, (int)txN.Value, ia, id, ie, ka, kd, ke);
                        }
                        else if (rbGouraud.Checked)//goura
                        {
                            draw.scanLineGouraud(bmpPrincipal, obj, tx, ty, Luz, Eye, (int)txN.Value, ia, id, ie, ka, kd, ke);
                        }
                        else // phong
                            draw.scanLinePhong(bmpPrincipal, obj, tx, ty, Luz, Eye, (int)txN.Value, ia, id, ie, ka, kd, ke);
                    }
                    pbPrincipal.Refresh();
                    if (tcPrincipal.SelectedTab == tpVistas) // vistas
                    {
                        {
                            double s = (double)pbLateral.Width / pbPrincipal.Width;
                            Objeto3D obj2 = obj.getCopia();
                            draw.paintVistas(bmpPlanta, bmpFrontal, bmpLateral, lbCAmb.BackColor);
                            obj2.escala(s, s, s);
                            // planta
                            draw.writeObjeto3DParalelaZX(bmpPlanta, obj2, lbCMat.BackColor, ckFacesOcultas.Checked);
                            //frontal
                            draw.writeObjeto3DParalelaXY(bmpFrontal, obj2, bmpFrontal.Width >> 1, bmpFrontal.Height >> 1,
                                lbCMat.BackColor, ckFacesOcultas.Checked);
                            //lateral
                            draw.writeObjeto3DParalelaZY(bmpLateral, obj2, lbCMat.BackColor, ckFacesOcultas.Checked);
                            
                            pbPlanta.Refresh();
                            pbFrontal.Refresh();
                            pbLateral.Refresh();
                        }

                    }
                }



            }
            else if (bmpPrincipal != null)
            {
                draw.paint(bmpPrincipal, lbCAmb.BackColor);
                pbPrincipal.Refresh();
            }
        }
    }
}
