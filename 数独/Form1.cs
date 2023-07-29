using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 数独
{


    public partial class Form1 : System.Windows.Forms.Form
    {
        public int[,] sd = new int[9, 9];//存储数组
        int nan = Form2.nan;//变换次数
        int xian = Form2.xian;//初始显示个数
        int cuowucishu = 0;//错误次数
        int[] xianxuan = new int[81];//实现随机不重复显示的数组
        Random rd = new Random();
        Control control1=new Control();
        public void xtian()//获取选中的按钮并且高亮提示
        {           
            control1 = this.ActiveControl;
            gl(sd,(Button)control1);
        }
        public void tian(int[,] sd,Button b)//填空
        {
            //Control focusedControl = this.ActiveControl;
            char[] dq = control1.Name.ToCharArray();
            if (control1.Text == "")
            {
                if (b.Text == sd[int.Parse(dq[1].ToString()) - 1, int.Parse(dq[2].ToString()) - 1].ToString())
                {
                    control1.Text = b.Text;
                    gl(sd, b);
                    xian++;
                    if (xian == 81)
                    {
                        MessageBox.Show("成功");
                        Form f1 = new Form2();
                        f1.Show();
                        this.Hide();
                        //成功，重新调用
                    }
                }
                else
                {
                    MessageBox.Show("错误");
                    cuowucishu++;
                    if (cuowucishu >= 5)
                    {
                        MessageBox.Show("失败次数大于五次，重开了");
                        Form f1 = new Form2();
                        f1.Show();
                        this.Hide();
                    }
                    //报错
                }
            }
        }
        public void shangse(Button b)//上色高亮实现
        {           
            string wei = b.Name;
            char[] cw = new char[2];
            cw[0] = wei[1];cw[1] = wei[2];
            for (int i = 0; i < 3; i++)
            {
                for (int l = 0; l < 3; l++)
                {
                    int hs = (((int)cw[0] - 1) / 3) * 3+i-47;
                    int ls = (((int)cw[1] - 1) / 3) * 3+l-47;
                    string vs = 'b' + hs.ToString() + ls.ToString();
                    Button bet = new Button();
                    bet = (Button)this.Controls[vs];
                    if (bet!=null)
                    {
                        bet.BackColor = Color.Red;
                    }
                }
            }
            for (int i = 1; i <= 9; i++)
            {
                string vsh = "b" + cw[0] + i.ToString();
                string vsl = "b" + i.ToString() + cw[1];
                Button btbh = new Button();
                Button btbl = new Button();
                btbh = (Button)this.Controls[vsh];
                btbl = (Button)this.Controls[vsl];
                if (btbh != null)
                {
                    btbh.BackColor = Color.Red;
                }
                if (btbl != null)
                {
                    btbl.BackColor = Color.Red;
                }
            }
            b.BackColor = Color.Green;
        }
        public void gl(int[,] sd, Button b)//高亮单元格判定实现
        {
            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {              
                    string vss = 'b' + i.ToString() + j.ToString();
                    Button bbt = new Button();
                    bbt = (Button)this.Controls[vss];
                    if (bbt != null)
                    {
                        bbt.BackColor = SystemColors.Control;
                    }
                }
            }
            if (b.Text == "")
            {
                shangse(b);
                b.BackColor = Color.Green;

            }
            else
            {          
            string xz = b.Text;
            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {                  
                    string vss = 'b' + i.ToString() + j.ToString();
                    Button bbt = new Button();                  
                    bbt = (Button)this.Controls[vss];
                    if (bbt != null)
                    {
                        if (bbt.Text == xz)
                        {                              
                                shangse(bbt);
                                bbt.BackColor = Color.Green;
                            }
                        }

                }
            }
        }
        }
        
        private void button_Click(object sender, EventArgs e)
        {

        }

        public void hanghuan3(int[,] sd)//三行之间交换
        {
            int qu = rd.Next(3);
            //int huan = (qu - rd.Next(3)+3)%3;
            int huan = qu - rd.Next(3);
            int[,] tmp = new int[3, 9];
            for (int i = qu*3; i < (qu+1)*3; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    tmp[i % 3, j] = sd[i, j];
                    sd[i, j] = sd[i - huan * 3,j];
                    sd[i - huan * 3, j] = tmp[i % 3, j];
                }
            }
        }

        public void liehuan3(int[,] sd)//三列之间交换
        {
            int qu = rd.Next(3);
            //int huan = (qu - rd.Next(3) + 3) % 3;
            int huan = qu - rd.Next(3);
            int[,] tmp = new int[9, 3];
            for (int i = qu * 3; i < (qu + 1) * 3; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    tmp[j, i % 3] = sd[j, i];
                    sd[j, i] = sd[j,i - (huan * 3)];
                    sd[j,i - huan * 3 ] = tmp[j,i % 3];
                }
            }
        }

        public void hanghuan(int[,] sd)//三行内单行之间交换
        {
            int qu = rd.Next(3);
            int qu1 = rd.Next(3);
            int qu2 = rd.Next(3);
            //int huan = qu - qu2;
            int[] tmp = new int[9];
            for (int i = 0; i < 9; i++)
            {
                tmp[i] = sd[qu * 3 + qu1, i];
                sd[qu * 3 + qu1, i] = sd[qu * 3 + qu2, i];
                sd[qu * 3 + qu2, i] = tmp[i];
            }
        }

        public void liehuan(int[,] sd)//三列内单列之间交换
        {
            int qu = rd.Next(3);
            int qu1 = rd.Next(3);
            int qu2 = rd.Next(3);
            //int huan = qu - qu2;
            int[] tmp = new int[9];
            for (int i = 0; i < 9; i++)
            {
                tmp[i] = sd[i, qu * 3 + qu1];
                sd[i,qu * 3 + qu1] = sd[i,qu * 3 + qu2];
                sd[i,qu * 3 + qu2] = tmp[i];
            }
        }


        public Form1()
        {
            InitializeComponent();
            //初始化一个符合数独规则的数组
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    sd[i, ((j+i*3)+(i/3))%9] = j+1;
                    xianxuan[i * 9 + j] = i * 9 + j;
                }
            }
            //实现按照变换次数随机进行行列四种变换
            for (int i = 0; i < nan; i++)
            {
                int shi = rd.Next(4);
                switch (shi)
                {
                    case 0: hanghuan3(sd); break;
                    case 1: hanghuan(sd); break;
                    case 2: liehuan3(sd); break;
                    case 3: liehuan(sd); break;
                    default:
                        break;
                }
            }
            //实现按照初始显示个数随机位置显示
            for (int i = 0; i < xian; i++)
            {
                int r = xianxuan.Length;
                int xuandao = rd.Next(xianxuan.Length);
                int xuanzhong = xianxuan[xuandao];
                ArrayList ked = new ArrayList(xianxuan);
                ked.RemoveAt(xuandao);
                xianxuan = (int[])ked.ToArray(typeof(int));
                r = r--;
                int xh = xuanzhong / 9+1;int xl = xuanzhong % 9+1;
                string vs = 'b' + xh.ToString() + xl.ToString();
                Button bet = new Button();
                bet = (Button)this.Controls[vs];
                if (bet != null)
                {
                    bet.Text = sd[xh - 1, xl - 1].ToString();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            xtian();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button67_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button56_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button57_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button58_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button59_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button60_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button61_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button62_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button63_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button64_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button65_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button66_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button55_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button68_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button69_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button70_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button71_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button72_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button73_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button74_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button75_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button76_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button77_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button78_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button79_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button80_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button81_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button52_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button51_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button50_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button41_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button40_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void button89_Click(object sender, EventArgs e)
        {
            tian(sd, b2);
        }

        private void b37_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void b1_Click(object sender, EventArgs e)
        {
            tian(sd, b1);
        }

        private void b3_Click(object sender, EventArgs e)
        {
            tian(sd, b3);
        }

        private void b4_Click(object sender, EventArgs e)
        {
            tian(sd, b4);
        }

        private void b5_Click(object sender, EventArgs e)
        {
            tian(sd, b5);
        }

        private void b6_Click(object sender, EventArgs e)
        {
            tian(sd, b6);
        }

        private void b7_Click(object sender, EventArgs e)
        {
            tian(sd, b7);
        }

        private void b8_Click(object sender, EventArgs e)
        {
            tian(sd, b8);
        }

        private void b9_Click(object sender, EventArgs e)
        {
            tian(sd, b9);
        }

        private void b11_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void b19_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void b21_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void b22_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void b23_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void b24_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void b25_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void b26_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void b27_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void b29_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void b31_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void b32_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void b33_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void b34_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void b35_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void b36_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void b41_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void b42_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void b46_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void b47_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void b48_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void b49_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void b51_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void b52_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void b53_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void b54_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void b54_Click_1(object sender, EventArgs e)
        {
            xtian();
        }

        private void b57_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void b58_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void b59_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void b61_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void b62_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void b64_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void b65_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void b66_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void b67_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void b68_Click(object sender, EventArgs e)
        {
            xtian();
        }

        private void b69_Click(object sender, EventArgs e)
        {
            xtian();
        }
    }
}
