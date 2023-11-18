namespace grupo3.prototipos.CAI
{
    partial class MenuPrincipalForm
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
            CrearItinerarioButton = new Button();
            BuscarItinerarioButton = new Button();
            SuspendLayout();
            // 
            // CrearItinerarioButton
            // 
            CrearItinerarioButton.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            CrearItinerarioButton.Location = new Point(164, 80);
            CrearItinerarioButton.Margin = new Padding(3, 4, 3, 4);
            CrearItinerarioButton.Name = "CrearItinerarioButton";
            CrearItinerarioButton.Size = new Size(292, 103);
            CrearItinerarioButton.TabIndex = 0;
            CrearItinerarioButton.Text = "Crear itinerario";
            CrearItinerarioButton.UseVisualStyleBackColor = true;
            CrearItinerarioButton.Click += NuevoItinerarioBtn_Click;
            // 
            // BuscarItinerarioButton
            // 
            BuscarItinerarioButton.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            BuscarItinerarioButton.Location = new Point(164, 217);
            BuscarItinerarioButton.Margin = new Padding(3, 4, 3, 4);
            BuscarItinerarioButton.Name = "BuscarItinerarioButton";
            BuscarItinerarioButton.Size = new Size(292, 103);
            BuscarItinerarioButton.TabIndex = 1;
            BuscarItinerarioButton.Text = "Buscar itinerario";
            BuscarItinerarioButton.UseVisualStyleBackColor = true;
            BuscarItinerarioButton.Click += BuscarItinerarioBtn_Click;
            // 
            // BuscaroCrearItForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(614, 427);
            Controls.Add(BuscarItinerarioButton);
            Controls.Add(CrearItinerarioButton);
            Margin = new Padding(3, 4, 3, 4);
            Name = "BuscaroCrearItForm";
            Text = "Pantalla principal";
            ResumeLayout(false);
        }

        #endregion

        private Button CrearItinerarioButton;
        private Button BuscarItinerarioButton;
    }
}