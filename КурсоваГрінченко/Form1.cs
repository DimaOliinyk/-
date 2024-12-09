namespace КурсоваГрінченко
{
    public partial class Form1 : Form
    {
        // Випадкові значення використовуватимуться для створення кольорів
        private Random _rnd = new Random();

        public Form1()
        {
            InitializeComponent();

            // Встановлюємо види діаграм
            comboBoxChartType.DataSource = new string[] 
            { 
                "Лінійна діаграма", 
                "Стовпчикова діаграма", 
                "Кругова діаграма" 
            };
            comboBoxChartType.DropDownStyle = ComboBoxStyle.DropDownList;   
        }

        /// <summary>
        /// Побудова діаграм
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDraw_Click(object sender, EventArgs e)
        {
            DataInterpreter.Read(textBoxData.Text, out double[]? data);   // Перетворюємо вказані значення
            var charType = ((ChartType)comboBoxChartType.SelectedIndex);  // Отримуємо тип діаграми

            // Якщо невдалось перетворити - значення повідомляємо користувача про помилку
            if (data is null)   
            {
                DrawString(pictureBoxChart.CreateGraphics(), "Некоректно введені значення");
                return; 
            }

            // Обираємо відповідний метод для побудови діаграм
            switch (charType) 
            {
                case ChartType.Line:
                    DrawLineChar(pictureBoxChart.CreateGraphics(), data);
                    break;
                case ChartType.Bar:
                    DrawBarChart(pictureBoxChart.CreateGraphics(), data);
                    break;
                case ChartType.Pie:
                    DrawPieChart(pictureBoxChart.CreateGraphics(), data);
                    break;
                default:
                    DrawString(pictureBoxChart.CreateGraphics(), "Функція для побудови діаграми не знайдена");
                    break;
            }
        }

        /// <summary>
        /// Метод для побудови лінійної діаграми
        /// </summary>
        /// <param name="g"></param>
        /// <param name="data"></param>
        private void DrawLineChar(Graphics g, double[] data)
        {
            var height = pictureBoxChart.Height * 0.8;
            Pen p;
            Brush b;
            var max = data.Max();
            var min = data.Min();
            int step = pictureBoxChart.Width / data.Length;
            int xStart = 0;
            int y = (int)(pictureBoxChart.Height - (Interpolate(data[0], min, max)) * height);

            // Малюємо перше значення у вигаляді рядка
            g.DrawString(
                $"{data[0]:0.0}",
                new Font("Times New Roman", step * 0.08f),
                b = new SolidBrush(Color.Black),
                10f,
                (y < 450) ? y - 15f : y - 30f);

            for (int i = 1; i < data.Length; i++)
            {
                // Малюємо ланку між двома сусідніми значеннями 
                g.DrawLine(
                    p = new Pen(Color.FromArgb(_rnd.Next(128), _rnd.Next(128), _rnd.Next(128)), 2f), 
                    xStart,
                    y,
                    xStart += step,
                    y = (int)(pictureBoxChart.Height - (Interpolate(data[i], min, max)) * height));

                // Малюємо наступне значення у вигаляді рядка
                g.DrawString(
                    $"{data[i]:0.0}",
                    new Font("Times New Roman", step * 0.08f),
                    b = new SolidBrush(Color.Black),
                    i * step + 10f,
                    (y < 450) ? y : y - 30f);
            }
        }

        /// <summary>
        /// Метод для побудови стовпчастої діаграми
        /// </summary>
        /// <param name="g"></param>
        /// <param name="data"></param>
        private void DrawBarChart(Graphics g, double[] data)
        {
            float height = pictureBoxChart.Height * 0.8f;
            Brush b;
            Brush bStr = new SolidBrush(Color.White);
            var max = data.Max();
            var min = data.Min();
            int step = pictureBoxChart.Width / data.Length;
            int y = 0;

            for (int i = 0; i < data.Length; i++)
            {
                // Малюємо прямокутник (стовпчик)
                g.FillRectangle(
                    // Підбирається випадковий темний колір 
                    b = new SolidBrush(Color.FromArgb(_rnd.Next(128), _rnd.Next(128), _rnd.Next(128))), 
                    i * step,
                    y = (int)(pictureBoxChart.Height - (Interpolate(data[i], min, max)) * height),
                    (int)(step * 0.8),
                    pictureBoxChart.Height);

                // Малюємо значення у вигаляді рядка
                g.DrawString(
                    $"{data[i]:0.0}",
                    new Font("Times New Roman", step * 0.08f),
                    (y < 450) ? bStr : b,    // Якщо значення не вміщається у прямокутник - малюємо над стовпчиком та іншим кольором
                    i * step + step * 0.25f,
                    (y < 450) ? y : y - 20f);
            }
        }

        /// <summary>
        /// Метод для побудови кругової діаграми
        /// </summary>
        /// <param name="g"></param>
        /// <param name="data"></param>
        private void DrawPieChart(Graphics g, double[] data)
        {
            // Прямокутник у який малюватиметься круг
            Rectangle rect = new Rectangle(
                pictureBoxChart.Width / 4,
                pictureBoxChart.Height / 6, 
                pictureBoxChart.Width / 2, 
                pictureBoxChart.Width / 2);
            
            var startAngle = 0.0f;
            var total = data.Sum();

            for (int i = 0; i < data.Length; i++)
            {
                // Підбирається випадковий темний колір
                Brush b = new SolidBrush(Color.FromArgb(_rnd.Next(128), _rnd.Next(128), _rnd.Next(128)));
                
                // Кут сектора визначається співвідношенням і-того значення до сумарного
                float sweepAngle = (float)(data[i] / total * 360f);
                g.FillPie(b, rect, startAngle, sweepAngle);
                startAngle += sweepAngle;
            }
        }

        /// <summary>
        /// Очищення полотна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            pictureBoxChart.Image = null;
        }

        /// <summary>
        /// Метод перетворення значення у лінійне співвідношення
        /// </summary>
        /// <param name="val"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        private double Interpolate(double val, double min, double max) 
        {
            if (max - min == 0)
                return 0.5;
            return val / (max - min);
        }

        /// <summary>
        /// Метод малювання повідомлення на полотні
        /// </summary>
        /// <param name="g"></param>
        /// <param name="text"></param>
        private void DrawString(Graphics g, string text) 
        {
            var fontSize = pictureBoxChart.Width / 30f;
            g.DrawString(
                text, 
                new Font("Times New Roman", fontSize),
                new SolidBrush(Color.DarkRed),
                (pictureBoxChart.Width - text.Length * fontSize) / 2f,
                pictureBoxChart.Height / 2f - fontSize);
        }
    }
}
