using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;


namespace mixboard
{
    public partial class form1 : Form
    {
        public form1()
        {
            InitializeComponent();
        }

        //location menu : 730; -8
        //ventana abierta 923; 562
        //ventana cerrada 739; 562

        string[] direcA = new string[17];
        string[] direcB = new string[17];
        string[] direcC = new string[17];
        string[] direcD = new string[17];

        Button[] botonesA = new Button[17];
        Button[] botonesB = new Button[17];
        Button[] botonesC = new Button[17];
        Button[] botonesD = new Button[17];

        Color[] colores = new Color[6];

        Image[] btncolores = new Image[6];

        AxWMPLib.AxWindowsMediaPlayer[] WMPA = new AxWMPLib.AxWindowsMediaPlayer[17];
        AxWMPLib.AxWindowsMediaPlayer[] WMPB = new AxWMPLib.AxWindowsMediaPlayer[17];


        bool[] playingboton = new bool[17];


        int colorselecA = 0;
        int colorselecB = 0;
        int colorselecC = 0;
        int colorselecD = 0;

        int colorandom = 0;

        string direccion = "";

        int numeroboton = 0;

        int numsectorr = -1;

        bool modoplay = true;

        string direccionactual = "";


        private void Form1_Load(object sender, EventArgs e)
        {
            this.Focus();
            this.Size = new System.Drawing.Size(739, 562);

            botonesA[1] = btna1;
            botonesA[2] = btna2;
            botonesA[3] = btna3;
            botonesA[4] = btna4;
            botonesA[5] = btna5;
            botonesA[6] = btna6;
            botonesA[7] = btna7;
            botonesA[8] = btna8;
            botonesA[9] = btna9;
            botonesA[10] = btna10;
            botonesA[11] = btna11;
            botonesA[12] = btna12;
            botonesA[13] = btna13;
            botonesA[14] = btna14;
            botonesA[15] = btna15;
            botonesA[16] = btna16;

            botonesB[1] = btnb1;



             
            colores[0] = Color.PaleGreen;
            colores[1] = Color.Gold;       //amarillo
            colores[2] = Color.DarkCyan;
            colores[3] = Color.Crimson; //rojo
            colores[4] = Color.Coral;

            btncolores[0] = Properties.Resources.btnverde;
            btncolores[1] = Properties.Resources.btnamarillo;
            btncolores[2] = Properties.Resources.btnceleste;
            btncolores[3] = Properties.Resources.btnrojo;
            btncolores[4] = Properties.Resources.btnnaranja;


            //Array de objetos windows media player
            WMPA[1] = wmpa1;
            WMPA[2] = wmpa2;
            WMPA[3] = wmpa3;
            WMPA[4] = wmpa4;
            WMPA[5] = wmpa5;
            WMPA[6] = wmpa6;
            WMPA[7] = wmpa7;
            WMPA[8] = wmpa8;
            WMPA[9] = wmpa9;
            WMPA[10] = wmpa10;
            WMPA[11] = wmpa11;
            WMPA[12] = wmpa12;
            WMPA[13] = wmpa13;
            WMPA[14] = wmpa14;
            WMPA[15] = wmpa15;
            WMPA[16] = wmpa16;

            WMPB[1] = wmpb1;


            //Array de playing de cada botón
            bool playing1 = false;
            bool playing2 = false;
            bool playing3 = false;
            bool playing4 = false;
            bool playing5 = false;
            bool playing6 = false;
            bool playing7 = false;
            bool playing8 = false;
            bool playing9 = false;
            bool playing10 = false;
            bool playing11= false;
            bool playing12 = false;
            bool playing13 = false;
            bool playing14 = false;
            bool playing15 = false;
            bool playing16 = false;

            playingboton[1] = playing1;
            playingboton[2] = playing2;
            playingboton[3] = playing3;
            playingboton[4] = playing4;
            playingboton[5] = playing5;
            playingboton[6] = playing6;
            playingboton[7] = playing7;
            playingboton[8] = playing8;
            playingboton[9] = playing9;
            playingboton[10] = playing10;
            playingboton[11] = playing11;
            playingboton[12] = playing12;
            playingboton[13] = playing13;
            playingboton[14] = playing14;
            playingboton[15] = playing15;
            playingboton[16] = playing16;

            


            int mostrarletras = 1;
            aplicar_texto_a_boton(mostrarletras);
            
        }
        public void playbotonA(int indice, string sector) //hacer switch para que funcion abarque todos los sectores
        {
            switch (sector)
            {
                case "A":
                    if (direcA[indice] == null)
                    {
                        MessageBox.Show("El boton no tiene un sonido asignado");
                    }
                    else
                    {
                        if (WMPA[indice].playState == WMPLib.WMPPlayState.wmppsPlaying)
                        {
                            return;
                        }
                        WMPA[indice].URL = direcA[indice];
                        WMPA[indice].Ctlcontrols.play();
                        Random random = new Random();
                        int randomNumber = random.Next(0, 5);
                        btncolores[5] = btncolores[randomNumber];
                        botonesA[indice].Image = btncolores[colorselecA];
                        // LOOP: wmpa1.settings.setMode("loop", true);

                    }
                    break;
                case "B":
                    if (direcB[indice] == null)
                    {
                        MessageBox.Show("El boton no tiene un sonido asignado");
                    }
                    else
                    {
                        if (WMPB[indice].playState == WMPLib.WMPPlayState.wmppsPlaying)
                        {
                            return;
                        }
                        WMPB[indice].URL = direcB[indice];
                        WMPB[indice].Ctlcontrols.play();
                        Random random = new Random();
                        int randomNumber = random.Next(0, 5);
                        btncolores[5] = btncolores[randomNumber];
                        botonesB[indice].Image = btncolores[colorselecB];
                        // LOOP: wmpa1.settings.setMode("loop", true);

                    }
                    break;
            }

            
        }
        public void cargarconclick(int indice, string sector)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Seleccionar sonido";
            open.Filter = "Archivo de Audio|*.wav";
            if (open.ShowDialog() == DialogResult.OK)
            {
                txtrutasonido.Text = open.FileName;
                direccionactual = open.FileName;

            }
            open.Dispose();
            switch (sector)
            {
                case "A":
                    direcA[indice] = direccionactual;
                    if (direcA[indice] != null)
                    {
                        botonesA[indice].ForeColor = Color.GreenYellow;
                    }
                    break;
                case "B":
                    direcB[indice] = direccionactual;
                    if (direcB[indice] != null)
                    {
                       // botonesB[indice].ForeColor = Color.GreenYellow;
                    }
                    break;
            }
            


        }
        public void soltarbotonA(int indice)
        {
            botonesA[indice].Image = Properties.Resources.btndefault;
            if (WMPA[indice].playState != WMPLib.WMPPlayState.wmppsPlaying)
            {
                return;
            }
            WMPA[indice].Ctlcontrols.stop();
        }

        public void aplicar_texto_a_boton(int e)
        {
            if (e == 1)
            {
                for (int i = 1; i < 17; i++)
                {
                    botonesA[i].ForeColor = Color.White;
                }
                btna1.Text = "1";
                btna2.Text = "2";
                btna3.Text = "3";
                btna4.Text = "4";
                btna5.Text = "q";
                btna6.Text = "w";
                btna7.Text = "e";
                btna8.Text = "r";
                btna9.Text = "a";
                btna10.Text = "s";
                btna11.Text = "d";
                btna12.Text = "f";
                btna13.Text = "z";
                btna14.Text = "x";
                btna15.Text = "c";
                btna16.Text = "v";

                btnb1.Text = "5";
            }
            else
            {
                for (int i = 1; i < 17; i++)
                {
                    botonesA[i].Text = "•";
                }
            }
        }

        private void btncargarboton_Click(object sender, EventArgs e)
        {
            if (cmbboton.Text != "Boton" && cmbsector.Text != "Sector")
            {
                direccion = txtrutasonido.Text;
                numeroboton = Convert.ToInt16(cmbboton.Text);
                switch (cmbsector.Text)
                {
                    case "A":
                        //asignacion de direccion a cada boton
                        direcA[numeroboton] = direccion;
                        //cambio de color si esta asignado un sonido
                        if (direcA[numeroboton] != null)
                        {
                            botonesA[numeroboton].ForeColor = Color.GreenYellow;
                        }

                        break;
                    case "B":
                        direcB[numeroboton] = direccion;
                        break;
                    case "C":
                        direcC[numeroboton] = direccion;
                        break;
                    case "D":
                        direcD[numeroboton] = direccion;
                        break;
                }
            }
        }
        private void btnrestablecer_Click(object sender, EventArgs e)
        {
            direccion = txtrutasonido.Text;
            numeroboton = Convert.ToInt16(cmbboton.Text);
            switch (cmbsector.Text)
            {
                case "A":

                    if (direcA[numeroboton] == null)
                    {
                        MessageBox.Show("El boton ya está vacio");
                    }
                    else
                    {
                        direcA[numeroboton] = null;
                        botonesA[numeroboton].ForeColor = Color.White;
                    }
                    break;
                case "B":
                    direcB[numeroboton] = direccion;
                    break;
                case "C":
                    direcC[numeroboton] = direccion;
                    break;
                case "D":
                    direcD[numeroboton] = direccion;
                    break;
            }
        }

        public void btnbuscar_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Seleccionar sonido";
            open.Filter = "Archivo de Audio|*.wav;*.mp3";
            if (open.ShowDialog() == DialogResult.OK)
            {
                txtrutasonido.Text = open.FileName;
                direccionactual = open.FileName;
            }
            open.Dispose();

        }
        bool playing = false;

        public void form1_KeyDown(object sender, KeyEventArgs e) {
            //SECTOR A
            switch (e.KeyCode)
            {
                case Keys.D1:
                    if (modoplay == true) playbotonA(1, "A");
                    
                    break;
                case Keys.D2:
                    if (modoplay == true) playbotonA(2, "A");
                    break;
                case Keys.D3:
                    if (modoplay == true) playbotonA(3, "A");
                    break;
                case Keys.D4:
                    if (modoplay == true) playbotonA(4, "A");
                    break;
                case Keys.Q:
                    if (modoplay == true) playbotonA(5, "A");
                    break;
                case Keys.W:
                    if (modoplay == true) playbotonA(6, "A");
                    break;
                case Keys.E:
                    if (modoplay == true) playbotonA(7, "A");
                    break;
                case Keys.R:
                    if (modoplay == true) playbotonA(8, "A");
                    break;
                case Keys.A:
                    if (modoplay == true) playbotonA(9, "A");
                    break;
                case Keys.S:
                    if (modoplay == true) playbotonA(10, "A");
                    break;
                case Keys.D:
                    if (modoplay == true) playbotonA(11, "A");
                    break;
                case Keys.F:
                    if (modoplay == true) playbotonA(12, "A");
                    break;
                case Keys.Z:
                    if (modoplay == true) playbotonA(13, "A");
                    break;
                case Keys.X:
                    if (modoplay == true) playbotonA(14, "A");
                    break;
                case Keys.C:
                    if (modoplay == true) playbotonA(15, "A");
                    break;
                case Keys.V:
                    if (modoplay == true) playbotonA(16, "A");
                    break;
            }

        }

        private void form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D1:
                    soltarbotonA(1);
                    break;
                case Keys.D2:
                    soltarbotonA(2);
                    break;
                case Keys.D3:
                    soltarbotonA(3);
                    break;
                case Keys.D4:
                    soltarbotonA(4);
                    break;
                case Keys.Q:
                    soltarbotonA(5);
                    break;
                case Keys.W:
                    soltarbotonA(6);
                    break;
                case Keys.E:
                    soltarbotonA(7);
                    break;
                case Keys.R:
                    soltarbotonA(8);
                    break;
                case Keys.A:
                    soltarbotonA(9);
                    break;
                case Keys.S:
                    soltarbotonA(10);
                    break;
                case Keys.D:
                    soltarbotonA(11);
                    break;
                case Keys.F:
                    soltarbotonA(12);
                    break;
                case Keys.Z:
                    soltarbotonA(13);
                    break;
                case Keys.X:
                    soltarbotonA(14);
                    break;
                case Keys.C:
                    soltarbotonA(15);
                    break;
                case Keys.V:
                    soltarbotonA(16);
                    break;
            }
            
        }

        private void btna2_Click_1(object sender, EventArgs e)
        {

        }

        private void form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //tecla maneteniendose presionada
        
        }


        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Se perderán los sonidos cargados al proyecto actual, ¿continuar creando un nuevo proyecto?", "Nuevo Proyecto", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                for (int i = 1; i < 10; i++)
                {
                    direcA[i] = null;
                    botonesA[i].ForeColor = Color.White;
                    //botonesB[i].ForeColor = Color.White;
                    //botonesC[i].ForeColor = Color.White;
                    //botonesD[i].ForeColor = Color.White;
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //hacer otra cosa
            }
        }






        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btngrabar_Click(object sender, EventArgs e)
        {


        }




        public static class Prompt
        {
            public static int ShowDialog(string text, string caption)
            {
                Form prompt = new Form();
                prompt.Width = 350;
                prompt.Height = 200;
                prompt.Text = caption;
                Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
                ComboBox cmbsec = new ComboBox() { Left = 50, Top = 50, Width = 100 };
                cmbsec.Items.Insert(0, "sector A");
                cmbsec.Items.Insert(1, "sector B");
                cmbsec.Items.Insert(2, "sector C");
                cmbsec.Items.Insert(3, "sector D");
                Button confirmation = new Button() { Text = "Ok", Left = 180, Width = 100, Top = 50 };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(cmbsec);
                prompt.ShowDialog();

                //MessageBox.Show(Convert.ToString(cmbsec.SelectedIndex));
                int numsector = cmbsec.SelectedIndex;
                return (int)numsector;

            }

        }

        private void mscolorluces_Click(object sender, EventArgs e)
        {

        }

        public void amarilloToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            int promptValue = Prompt.ShowDialog("Sector:", "Configurar color de luces");
            numsectorr = promptValue;
            switch (numsectorr)
            {
                case 0:
                    colorselecA = 1;
                    break;
                case 1:
                    colorselecB = 1;
                    break;
                case 2:
                    colorselecC = 1;
                    break;
                case 3:
                    colorselecD = 1;
                    break;
            }

        }

        private void celesteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int promptValue = Prompt.ShowDialog("Sector:", "Configurar color de luces");
            numsectorr = promptValue;
            switch (numsectorr)
            {
                case 0:
                    colorselecA = 2;
                    break;
                case 1:
                    colorselecB = 2;
                    break;
                case 2:
                    colorselecC = 2;
                    break;
                case 3:
                    colorselecD = 2;
                    break;
            }
        }

        private void verdedefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int promptValue = Prompt.ShowDialog("Sector:", "Configurar color de luces");
            numsectorr = promptValue;
            switch (numsectorr)
            {
                case 0:
                    colorselecA = 0;
                    break;
                case 1:
                    colorselecB = 0;
                    break;
                case 2:
                    colorselecC = 0;
                    break;
                case 3:
                    colorselecD = 0;
                    break;
            }
        }

        private void rojoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int promptValue = Prompt.ShowDialog("Sector:", "Configurar color de luces");
            numsectorr = promptValue;
            switch (numsectorr)
            {
                case 0:
                    colorselecA = 3;
                    break;
                case 1:
                    colorselecB = 3;
                    break;
                case 2:
                    colorselecC = 3;
                    break;
                case 3:
                    colorselecD = 3;
                    break;
            }
        }

        private void naranjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int promptValue = Prompt.ShowDialog("Sector:", "Configurar color de luces");
            numsectorr = promptValue;
            switch (numsectorr)
            {
                case 0:
                    colorselecA = 4;
                    break;
                case 1:
                    colorselecB = 4;
                    break;
                case 2:
                    colorselecC = 4;
                    break;
                case 3:
                    colorselecD = 4;
                    break;
            }
        }

        public void randomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int promptValue = Prompt.ShowDialog("Sector:", "Configurar color de luces");
            numsectorr = promptValue;


            switch (numsectorr)
            {
                case 0:
                    colorselecA = 5;
                    break;
                case 1:
                    colorselecB = 5;
                    break;
                case 2:
                    colorselecC = 5;
                    break;
                case 3:
                    colorselecD = 5;
                    break;
            }
        }






        public void pbdesplegar_Click(object sender, EventArgs e)
        {
            panelmenu.BringToFront();
            this.Size = new System.Drawing.Size(914, 562);

        }

        private void pbdesplegado_Click(object sender, EventArgs e)
        {
            panelvacio.BringToFront();
            this.Size = new System.Drawing.Size(739, 562);
        }

        private void gbvacioo_Enter(object sender, EventArgs e)
        {

        }
        private void pbdesplegado_MouseEnter(object sender, EventArgs e)
        {
            pbdesplegado.Image = Properties.Resources.atras;
        }

        private void pbdesplegado_MouseLeave(object sender, EventArgs e)
        {
            pbdesplegado.Image = Properties.Resources.logoedicion1;
        }

        private void pbdesplegar_MouseEnter(object sender, EventArgs e)
        {
            pbdesplegar.Image = Properties.Resources.logoedicionhover1;
        }

        private void pbdesplegar_MouseLeave(object sender, EventArgs e)
        {
            pbdesplegar.Image = Properties.Resources.logoedicionorange;

        }

        public void pbmodo_Click(object sender, EventArgs e)
        {
            if (modoplay == true)
            {
                //MODO EDICION
                pbmodo.Image = Properties.Resources.botonedicion;
                modoplay = false;
                lblmodo.Text = "Modo Edicion";
                pbdesplegar_Click(sender, e);


            }
            else
            {
                //MODO PLAY
                pbmodo.Image = Properties.Resources.botonsesion;
                modoplay = true;
                lblmodo.Text = "Modo Play";
                pbdesplegado_Click(sender, e);

            }

        }


        

        private void btna1_MouseDown(object sender, MouseEventArgs e)
        {
            if (modoplay == true) playbotonA(1, "A"); else cargarconclick(1, "A");
        }

        private void btna1_MouseUp(object sender, MouseEventArgs e)
        {
            soltarbotonA(1);
            
        }

        private void btna2_MouseDown(object sender, MouseEventArgs e)
        {
            if (modoplay == true) playbotonA(2, "A"); else cargarconclick(2, "A");
        }

        private void btna2_MouseUp(object sender, MouseEventArgs e)
        {
            soltarbotonA(2);
        }

        private void btna3_MouseDown(object sender, MouseEventArgs e)
        {
            if (modoplay == true) playbotonA(3, "A"); else cargarconclick(3, "A");
        }

        private void btna3_MouseUp(object sender, MouseEventArgs e)
        {
            soltarbotonA(3);
        }

        private void btna4_MouseDown(object sender, MouseEventArgs e)
        {
            if (modoplay == true) playbotonA(4, "A"); else cargarconclick(4, "A");
        }

        private void btna4_MouseUp(object sender, MouseEventArgs e)
        {
            soltarbotonA(4);
        }

        private void btna5_MouseDown(object sender, MouseEventArgs e)
        {
            if (modoplay == true) playbotonA(5, "A"); else cargarconclick(5, "A");
        }

        private void btna5_MouseUp(object sender, MouseEventArgs e)
        {
            soltarbotonA(5);
        }

        private void btna6_MouseDown(object sender, MouseEventArgs e)
        {
            if (modoplay == true) playbotonA(6, "A"); else cargarconclick(6, "A");
        }

        private void btna6_MouseUp(object sender, MouseEventArgs e)
        {
            soltarbotonA(6);
        }

        private void btna7_MouseDown(object sender, MouseEventArgs e)
        {
            if (modoplay == true) playbotonA(7, "A"); else cargarconclick(7, "A");
        }

        private void btna7_MouseUp(object sender, MouseEventArgs e)
        {
            soltarbotonA(7);
        }

        private void btna8_MouseDown(object sender, MouseEventArgs e)
        {
            if (modoplay == true) playbotonA(8, "A"); else cargarconclick(8, "A");
        }

        private void btna8_MouseUp(object sender, MouseEventArgs e)
        {
            soltarbotonA(8);
        }

        private void btna9_MouseDown(object sender, MouseEventArgs e)
        {
            if (modoplay == true) playbotonA(9, "A"); else cargarconclick(9, "A");
        }

        private void btna9_MouseUp(object sender, MouseEventArgs e)
        {
            soltarbotonA(9);
        }
        private void btnseleccionarcarpeta_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Seleccionar sonido";
            open.Filter = "Archivo de Audio|*.wav;*.mp3";
            open.Multiselect = true;
            if (open.ShowDialog() == DialogResult.OK)
            {
                txtseleccionarcarpeta.Text = open.FileName;
                int i = 1;
                string titulosonido = "";
                string sector = "";
                foreach (string file in open.FileNames)
                {
                    try {
                        titulosonido = System.IO.Path.GetFileNameWithoutExtension(file);
                        sector = titulosonido.Substring(0, 1);
                        numeroboton = Convert.ToInt16(titulosonido.Substring(1, 1));
                        switch (sector)
                        {
                            case "A":
                                direcA[numeroboton] = file;
                                botonesA[numeroboton].ForeColor = Color.GreenYellow;
                                break;
                            case "B":
                                direcB[numeroboton] = file;
                                botonesB[numeroboton].ForeColor = Color.GreenYellow;

                                break;
                            case "C":
                                direcC[numeroboton] = file;
                                botonesC[numeroboton].ForeColor = Color.GreenYellow;
                                break;
                            case "D":
                                direcD[numeroboton] = file;
                                botonesD[numeroboton].ForeColor = Color.GreenYellow;
                                break;
                        }


                    }

                    catch (Exception ex)
                    {
                        // Could not load the image - probably related to Windows file system permissions.
                        MessageBox.Show("No se puede cargar el sonido:" + file.Substring(file.LastIndexOf('\\'))
                            + ". Para cargar todos los sonidos desde carpeta, " +
                            "El nombre de cada archivo debe ser SECTOR(A,B,C o D) y NUMERO (1 a 9)" +
                            "\n\nEjemplo: A3.wav o B2.wav" +
                            "\n\nReported error: " + ex.Message);
                    }
                }
            }
            open.Dispose();
        }

        private void activarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aplicar_texto_a_boton(1);
        }

        private void desactivarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aplicar_texto_a_boton(0);
        }

        private void btna10_MouseDown(object sender, MouseEventArgs e)
        {
            if (modoplay == true) playbotonA(10, "A"); else cargarconclick(10, "A");
        }

        private void btna10_MouseUp(object sender, MouseEventArgs e)
        {
            soltarbotonA(10);
        }

        private void btna11_MouseDown(object sender, MouseEventArgs e)
        {
            if (modoplay == true) playbotonA(11, "A"); else cargarconclick(11, "A");
        }

        private void btna11_MouseUp(object sender, MouseEventArgs e)
        {
            soltarbotonA(11);
        }

        private void btna12_MouseDown(object sender, MouseEventArgs e)
        {
            if (modoplay == true) playbotonA(12, "A"); else cargarconclick(12, "A");
        }

        private void btna12_MouseUp(object sender, MouseEventArgs e)
        {
            soltarbotonA(12);
        }

        private void btna13_MouseDown(object sender, MouseEventArgs e)
        {
            if (modoplay == true) playbotonA(13, "A"); else cargarconclick(13, "A");
        }

        private void btna13_MouseUp(object sender, MouseEventArgs e)
        {
            soltarbotonA(13);
        }

        private void btna14_MouseDown(object sender, MouseEventArgs e)
        {
            if (modoplay == true) playbotonA(14, "A"); else cargarconclick(14, "A");
        }

        private void btna14_MouseUp(object sender, MouseEventArgs e)
        {
            soltarbotonA(14);
        }

        private void btna15_MouseDown(object sender, MouseEventArgs e)
        {
            if (modoplay == true) playbotonA(15, "A"); else cargarconclick(15, "A");
        }

        private void btna15_MouseUp(object sender, MouseEventArgs e)
        {
            soltarbotonA(15);
        }

        private void btna16_MouseDown(object sender, MouseEventArgs e)
        {
            if (modoplay == true) playbotonA(16, "A"); else cargarconclick(16, "A");
        }

        private void btna16_MouseUp(object sender, MouseEventArgs e)
        {
            soltarbotonA(16);
        }

        private void btnb1_MouseDown(object sender, MouseEventArgs e)
        {
            if (modoplay == true) playbotonA(1, "B"); else cargarconclick(1, "B");

        }
    }
}
    
