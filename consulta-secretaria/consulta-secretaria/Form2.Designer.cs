namespace consulta_secretaria
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.boxJustificativa = new System.Windows.Forms.TextBox();
            this.enviarButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Justificativa:";
            // 
            // boxJustificativa
            // 
            this.boxJustificativa.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxJustificativa.Location = new System.Drawing.Point(12, 61);
            this.boxJustificativa.Multiline = true;
            this.boxJustificativa.Name = "boxJustificativa";
            this.boxJustificativa.Size = new System.Drawing.Size(598, 201);
            this.boxJustificativa.TabIndex = 1;
            // 
            // enviarButton
            // 
            this.enviarButton.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enviarButton.Location = new System.Drawing.Point(406, 301);
            this.enviarButton.Name = "enviarButton";
            this.enviarButton.Size = new System.Drawing.Size(99, 31);
            this.enviarButton.TabIndex = 2;
            this.enviarButton.Text = "Enviar";
            this.enviarButton.UseVisualStyleBackColor = true;
            this.enviarButton.Click += new System.EventHandler(this.enviarButton_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(511, 301);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 31);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 344);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.enviarButton);
            this.Controls.Add(this.boxJustificativa);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox boxJustificativa;
        private System.Windows.Forms.Button enviarButton;
        private System.Windows.Forms.Button button2;
    }
}