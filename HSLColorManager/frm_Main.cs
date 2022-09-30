namespace HSLColorManager
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }

        private string HslToHTML(int h, int s, int l)
        {
            var c = HslToRgb(h, s, l);
            return String.Format("#{0:X2}{1:X2}{2:X2}", c.R, c.G, c.B);
        }

        private Color HslToRgb(int h, int s, int l)
        {
            double r, g, b;
            double t1, t2;
            double th = h / 360.0;
            double sl = s / 100.0;
            double ll = l / 100.0;

            if (ll <= 0.5)
                t2 = ll * (1.0 + sl);
            else
                t2 = ll + sl - ll * sl;

            t1 = 2.0 * ll - t2;

            r = GetColorComponent(th + 1.0 / 3.0, t1, t2);
            g = GetColorComponent(th, t1, t2);
            b = GetColorComponent(th - 1.0 / 3.0, t1, t2);

            return Color.FromArgb(255, (int)(r * 255), (int)(g * 255), (int)(b * 255));
        }

        private double GetColorComponent(double tc, double t1, double t2)
        {
            double result;

            if (tc < 0.0)
                tc += 1.0;
            else if (tc > 1.0)
                tc -= 1.0;

            if (tc < 1.0 / 6.0)
                result = t1 + (t2 - t1) * 6.0 * tc;
            else if (tc < 1.0 / 2.0)
                result = t2;
            else if (tc < 2.0 / 3.0)
                result = t1 + (t2 - t1) * (2.0 / 3.0 - tc) * 6.0;
            else
                result = t1;

            return result;
        }



        private void nud_hsl_Hue_ValueChanged(object sender, EventArgs e)
        {
            lbl_Result_ToHEX.Text = HslToHTML((int)nud_hsl_Hue.Value, (int)nud_hsl_Saturation.Value, (int)nud_hsl_Lightness.Value).ToString();
            pnl_Result_Color.BackColor = ColorTranslator.FromHtml(lbl_Result_ToHEX.Text);
        }

        private void nud_hsl_Saturation_ValueChanged(object sender, EventArgs e)
        {
            lbl_Result_ToHEX.Text = HslToHTML((int)nud_hsl_Hue.Value, (int)nud_hsl_Saturation.Value, (int)nud_hsl_Lightness.Value).ToString();
            pnl_Result_Color.BackColor = ColorTranslator.FromHtml(lbl_Result_ToHEX.Text);
        }

        private void nud_hsl_Lightness_ValueChanged(object sender, EventArgs e)
        {
            lbl_Result_ToHEX.Text = HslToHTML((int)nud_hsl_Hue.Value, (int)nud_hsl_Saturation.Value, (int)nud_hsl_Lightness.Value).ToString();
            pnl_Result_Color.BackColor = ColorTranslator.FromHtml(lbl_Result_ToHEX.Text);
        }

        public string GenerateRgba(string hexBackgroundColor, decimal backgroundOpacity)
        {
            Color color = ColorTranslator.FromHtml(hexBackgroundColor);
            int r = Convert.ToInt16(color.R);
            int g = Convert.ToInt16(color.G);
            int b = Convert.ToInt16(color.B);
            return string.Format("rgba({0}, {1}, {2}, {3});", r, g, b, backgroundOpacity);
        }

        private void btn_hsl_Gerar_Click(object sender, EventArgs e)
        {
            (string lessHex, string hex, string moreHex) hex1 = GenerateHex((ushort)nud_hsl_LessMoreHue.Value, (ushort)nud_hsl_LessMoreSaturation.Value, (ushort)nud_hsl_LessMoreLightness.Value);

            lbl_hsl_Result_Color1_1.Text = hex1.moreHex;
            pnl_hsl_Result_Color1_1.BackColor = ColorTranslator.FromHtml(hex1.moreHex);

            lbl_hsl_Result_Color1_2.Text = hex1.hex;
            pnl_hsl_Result_Color1_2.BackColor = ColorTranslator.FromHtml(hex1.hex);

            lbl_hsl_Result_Color1_3.Text = hex1.lessHex;
            pnl_hsl_Result_Color1_3.BackColor = ColorTranslator.FromHtml(hex1.lessHex);


            (string lessHex, string hex, string moreHex) hex2 = GenerateHex((ushort)nud_hsl_LessMoreHue.Value, (ushort)nud_hsl_LessMoreSaturation.Value, (ushort)nud_hsl_LessMoreLightness.Value);

            lbl_hsl_Result_Color2_1.Text = hex2.moreHex;
            pnl_hsl_Result_Color2_1.BackColor = ColorTranslator.FromHtml(hex2.moreHex);

            lbl_hsl_Result_Color2_2.Text = hex2.hex;
            pnl_hsl_Result_Color2_2.BackColor = ColorTranslator.FromHtml(hex2.hex);

            lbl_hsl_Result_Color2_3.Text = hex2.lessHex;
            pnl_hsl_Result_Color2_3.BackColor = ColorTranslator.FromHtml(hex2.lessHex);


            (string lessHex, string hex, string moreHex) hex3 = GenerateHex((ushort)nud_hsl_LessMoreHue.Value, (ushort)nud_hsl_LessMoreSaturation.Value, (ushort)nud_hsl_LessMoreLightness.Value);

            lbl_hsl_Result_Color3_1.Text = hex3.moreHex;
            pnl_hsl_Result_Color3_1.BackColor = ColorTranslator.FromHtml(hex3.moreHex);

            lbl_hsl_Result_Color3_2.Text = hex3.hex;
            pnl_hsl_Result_Color3_2.BackColor = ColorTranslator.FromHtml(hex3.hex);

            lbl_hsl_Result_Color3_3.Text = hex3.lessHex;
            pnl_hsl_Result_Color3_3.BackColor = ColorTranslator.FromHtml(hex3.lessHex);
        }

        (string lessHex, string hex, string moreHex) GenerateHex(ushort lessMoreHue = 0, ushort lessMoreSaturation = 0, ushort lessMoreLightness = 0)
        {
            Random rnd = new Random();

            int h = rnd.Next((int)nud_hsl_HueMin.Value, (int)nud_hsl_HueMax.Value);
            int s = rnd.Next((int)nud_hsl_SaturationMin.Value, (int)nud_hsl_SaturationMax.Value);
            int l = rnd.Next((int)nud_hsl_LightnessMin.Value, (int)nud_hsl_LightnessMax.Value);

            int mh = h + lessMoreHue > 360 ? 360 : h + lessMoreHue;
            int ms = s + lessMoreSaturation > 100 ? 100 : s + lessMoreSaturation;
            int ml = l + lessMoreLightness > 100 ? 100 : l + lessMoreLightness;

            int lh = h - lessMoreHue < 0 ? 0 : h - lessMoreHue;
            int ls = s - lessMoreSaturation < 0 ? 0 : s - lessMoreSaturation;
            int ll = l - lessMoreLightness < 0 ? 0 : l - lessMoreLightness;

            return (HslToHTML(lh, ls, ll).ToString(),
                   HslToHTML(h, s, l).ToString(),
                   HslToHTML(mh, ms, ml).ToString());
        }

        private void btn_hsl_Presets_Pure_Click(object sender, EventArgs e)
        {
            nud_hsl_SaturationMin.Value = 100;
            nud_hsl_SaturationMax.Value = 100;
            nud_hsl_LightnessMin.Value = 50;
            nud_hsl_LightnessMax.Value = 50;
        }

        private void btn_hsl_Presets_Pastel_Click(object sender, EventArgs e)
        {
            nud_hsl_SaturationMin.Value = 60;
            nud_hsl_SaturationMax.Value = 60;
            nud_hsl_LightnessMin.Value = 70;
            nud_hsl_LightnessMax.Value = 70;
        }

        private void btn_hsl_Presets_Light_Click(object sender, EventArgs e)
        {
            nud_hsl_SaturationMin.Value = 100;
            nud_hsl_SaturationMax.Value = 100;
            nud_hsl_LightnessMin.Value = 75;
            nud_hsl_LightnessMax.Value = 75;
        }

        private void btn_hsl_Presets_Dark_Click(object sender, EventArgs e)
        {
            nud_hsl_SaturationMin.Value = 100;
            nud_hsl_SaturationMax.Value = 100;
            nud_hsl_LightnessMin.Value = 25;
            nud_hsl_LightnessMax.Value = 25;
        }

        

        private void pnl_Result_Color_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetText(lbl_Result_ToHEX.Text);
        }

        private void btn_hsl_Presets_Lightness_20_Click(object sender, EventArgs e)
        {
            nud_hsl_Lightness.Value = 20;
        }

        private void btn_hsl_Presets_Lightness_50_Click(object sender, EventArgs e)
        {
            nud_hsl_Lightness.Value = 50;
        }

        private void btn_hsl_Presets_Lightness_80_Click(object sender, EventArgs e)
        {
            nud_hsl_Lightness.Value = 80;
        }

        private void pnl_hsl_Result_Color1_1_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetText(lbl_hsl_Result_Color1_1.Text);
        }

        private void pnl_hsl_Result_Color2_1_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetText(lbl_hsl_Result_Color2_1.Text);
        }

        private void pnl_hsl_Result_Color3_1_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetText(lbl_hsl_Result_Color3_1.Text);
        }

        private void pnl_hsl_Result_Color1_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetText(lbl_hsl_Result_Color1_2.Text);
        }

        private void pnl_hsl_Result_Color2_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetText(lbl_hsl_Result_Color2_2.Text);
        }

        private void pnl_hsl_Result_Color3_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetText(lbl_hsl_Result_Color3_2.Text);
        }

        private void pnl_hsl_Result_Color1_3_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetText(lbl_hsl_Result_Color1_3.Text);
        }

        private void pnl_hsl_Result_Color2_3_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetText(lbl_hsl_Result_Color2_3.Text);
        }

        private void pnl_hsl_Result_Color3_3_DoubleClick(object sender, EventArgs e)
        {
            Clipboard.SetText(lbl_hsl_Result_Color3_3.Text);
        }
    }
}