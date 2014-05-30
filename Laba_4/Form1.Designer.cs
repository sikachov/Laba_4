using System;

namespace Laba_4
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        private void InitializeComponent(int width, int height, int[][] g)
        {
            int n = g.GetLength(0);
            int m = g[0].GetLength(0);

            double angle_size = 2.0 * System.Math.PI / n;
            int begin_x = width / 2;
            int begin_y = (int)(Math.Min(width, height) * 0.1);
            int radius = (int)(Math.Min(width, height) * 0.4);

            this.SuspendLayout();

            this.pictureBoxes = new System.Windows.Forms.PictureBox[n];
            this.labels = new System.Windows.Forms.Label[n];
            this.lines = new Microsoft.VisualBasic.PowerPacks.LineShape[m];
            this.arrows = new System.Collections.Generic.LinkedList<Microsoft.VisualBasic.PowerPacks.LineShape>();

            for (int i = 0; i < n; i++)
            {
                this.pictureBoxes[i] = new System.Windows.Forms.PictureBox();
                this.labels[i] = new System.Windows.Forms.Label();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBoxes[i])).BeginInit();
                this.pictureBoxes[i].Image = global::Laba_4.Resource1.v;


                double angle = i * angle_size;
                int x = begin_x - 8 + (int)(Math.Sin(angle) * radius);
                int y = begin_y - 8 + (int)((1.0 - Math.Cos(angle)) * radius);

                this.pictureBoxes[i].Location = new System.Drawing.Point(x, y);
                this.pictureBoxes[i].Name = "pictureBox" + i;
                this.pictureBoxes[i].Size = new System.Drawing.Size(16, 16);
                this.pictureBoxes[i].TabIndex = 0;
                this.pictureBoxes[i].TabStop = false;
                ((System.ComponentModel.ISupportInitialize)(this.pictureBoxes[i])).EndInit();


                int label_width = 13 + ((i + 1) / 10) * 6;
                x = begin_x - label_width / 2 + (int)(Math.Sin(angle) * (radius + 20));
                y = begin_y - 26 + (int)((1.0 - Math.Cos(angle)) * (radius + 20));

                this.labels[i].AutoSize = true;
                this.labels[i].Location = new System.Drawing.Point(x, y);
                this.labels[i].Name = "label" + i;
                this.labels[i].Size = new System.Drawing.Size(0, 0);
                this.labels[i].TabIndex = 0;
                this.labels[i].Text = (i + 1).ToString();
            }

            for (int i = 0; i < m; i++)
            {
                int v1, v2;
                for (v1 = 0; v1 < n; v1++)
                    if (g[v1][i] != 0)
                        break;
                for (v2 = v1 + 1; v2 < n; v2++)
                    if (g[v2][i] != 0)
                        break;
                if (g[v1][i] == -1)
                {
                    int temp = v2;
                    v2 = v1;
                    v1 = temp;
                }
                this.lines[i] = new Microsoft.VisualBasic.PowerPacks.LineShape();
                this.lines[i].Name = "line" + i;
                this.lines[i].X1 = this.pictureBoxes[v1].Location.X + 8;
                this.lines[i].X2 = this.pictureBoxes[v2].Location.X + 8;
                this.lines[i].Y1 = this.pictureBoxes[v1].Location.Y + 8;
                this.lines[i].Y2 = this.pictureBoxes[v2].Location.Y + 8;
                if (g[v2][i] == -1)
                {
                    int x01, y01, x02, y02;
                    x01 = this.lines[i].X1;
                    x02 = this.lines[i].X2;
                    y01 = this.lines[i].Y1;
                    y02 = this.lines[i].Y2;

                    int dx = x02 - x01;
                    int dy = y02 - y01;

                    double angle = Math.Atan((double)dy / dx);
                    if (dx < 0)
                        angle += Math.PI;

                    int x1 = x02 - (int)(Math.Cos(angle) * 9);
                    int y1 = y02 - (int)(Math.Sin(angle) * 9);
                    int x2 = x1 + (int)(Math.Cos(angle + 0.93 * Math.PI) * 25);
                    int y2 = y1 + (int)(Math.Sin(angle + 0.93 * Math.PI) * 25);
                    int x3 = x1 + (int)(Math.Cos(angle - 0.93 * Math.PI) * 25);
                    int y3 = y1 + (int)(Math.Sin(angle - 0.93 * Math.PI) * 25);

                    Microsoft.VisualBasic.PowerPacks.LineShape line = new Microsoft.VisualBasic.PowerPacks.LineShape();
                    line.Name = "al0";
                    line.X1 = x1;
                    line.X2 = x2;
                    line.Y1 = y1;
                    line.Y2 = y2;
                    arrows.AddLast(line);

                    line = new Microsoft.VisualBasic.PowerPacks.LineShape();
                    line.Name = "al1";
                    line.X1 = x1;
                    line.X2 = x3;
                    line.Y1 = y1;
                    line.Y2 = y3;
                    arrows.AddLast(line);
                }
            }

            this.shapeContainer = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.shapeContainer.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer.Name = "shapeContainer";
            this.shapeContainer.Shapes.AddRange(lines);

            Microsoft.VisualBasic.PowerPacks.LineShape[] t = new Microsoft.VisualBasic.PowerPacks.LineShape[arrows.Count];
            arrows.CopyTo(t, 0);
            this.shapeContainer.Shapes.AddRange(t);

            this.shapeContainer.Size = new System.Drawing.Size(width, height);
            this.shapeContainer.TabIndex = 1;
            this.shapeContainer.TabStop = false;

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(width, height);
            for (int i = 0; i < n; i++)
            {
                this.Controls.Add(this.pictureBoxes[i]);
                this.Controls.Add(this.labels[i]);
            }
            this.Controls.Add(shapeContainer);
            this.Name = "Form1";
            this.Text = "Visual editor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox[] pictureBoxes;
        private System.Windows.Forms.Label[] labels;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer;
        private Microsoft.VisualBasic.PowerPacks.LineShape[] lines;
        private System.Collections.Generic.LinkedList<Microsoft.VisualBasic.PowerPacks.LineShape> arrows;
    }
}


