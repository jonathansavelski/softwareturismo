namespace grupo3.prototipos.CAI
{
    partial class BusquedaItinerarioForm
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
            ItinerarioListView = new ListView();
            fechaCreacionItinerarioHeader = new ColumnHeader();
            CotizacionHeader = new ColumnHeader();
            EstadoItinerarioHeader = new ColumnHeader();
            PagoHeader = new ColumnHeader();
            lblBuscarNumeroItinerario = new Label();
            txtBuscarItinerario = new TextBox();
            BuscarItinerarioBtn = new Button();
            VerDetallesBtn = new Button();
            groupBox1 = new GroupBox();
            RealizarReservaButton = new Button();
            RealizarPrereservaButton = new Button();
            ConfirmarReservaButton = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // ItinerarioListView
            // 
            ItinerarioListView.Columns.AddRange(new ColumnHeader[] { fechaCreacionItinerarioHeader, CotizacionHeader, EstadoItinerarioHeader, PagoHeader });
            ItinerarioListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            ItinerarioListView.HideSelection = true;
            ItinerarioListView.Location = new Point(15, 68);
            ItinerarioListView.Margin = new Padding(3, 4, 3, 4);
            ItinerarioListView.MultiSelect = false;
            ItinerarioListView.Name = "ItinerarioListView";
            ItinerarioListView.Size = new Size(658, 79);
            ItinerarioListView.TabIndex = 0;
            ItinerarioListView.UseCompatibleStateImageBehavior = false;
            ItinerarioListView.View = View.Details;
            // 
            // fechaCreacionItinerarioHeader
            // 
            fechaCreacionItinerarioHeader.Text = "Fecha de creación";
            fechaCreacionItinerarioHeader.TextAlign = HorizontalAlignment.Center;
            fechaCreacionItinerarioHeader.Width = 150;
            // 
            // CotizacionHeader
            // 
            CotizacionHeader.Text = "Cotización";
            CotizacionHeader.TextAlign = HorizontalAlignment.Center;
            CotizacionHeader.Width = 150;
            // 
            // EstadoItinerarioHeader
            // 
            EstadoItinerarioHeader.Text = "Estado";
            EstadoItinerarioHeader.TextAlign = HorizontalAlignment.Center;
            EstadoItinerarioHeader.Width = 100;
            // 
            // PagoHeader
            // 
            PagoHeader.Text = "¿Está Pago?";
            PagoHeader.TextAlign = HorizontalAlignment.Center;
            PagoHeader.Width = 100;
            // 
            // lblBuscarNumeroItinerario
            // 
            lblBuscarNumeroItinerario.AutoSize = true;
            lblBuscarNumeroItinerario.Location = new Point(13, 23);
            lblBuscarNumeroItinerario.Name = "lblBuscarNumeroItinerario";
            lblBuscarNumeroItinerario.Size = new Size(130, 20);
            lblBuscarNumeroItinerario.TabIndex = 1;
            lblBuscarNumeroItinerario.Text = "Número itinerario:";
            // 
            // txtBuscarItinerario
            // 
            txtBuscarItinerario.Location = new Point(161, 20);
            txtBuscarItinerario.Margin = new Padding(3, 4, 3, 4);
            txtBuscarItinerario.Name = "txtBuscarItinerario";
            txtBuscarItinerario.Size = new Size(114, 27);
            txtBuscarItinerario.TabIndex = 2;
            txtBuscarItinerario.KeyPress += txtBuscarItinerario_KeyPress;
            // 
            // BuscarItinerarioBtn
            // 
            BuscarItinerarioBtn.Location = new Point(298, 19);
            BuscarItinerarioBtn.Margin = new Padding(3, 4, 3, 4);
            BuscarItinerarioBtn.Name = "BuscarItinerarioBtn";
            BuscarItinerarioBtn.Size = new Size(129, 31);
            BuscarItinerarioBtn.TabIndex = 3;
            BuscarItinerarioBtn.Text = "Buscar";
            BuscarItinerarioBtn.UseVisualStyleBackColor = true;
            BuscarItinerarioBtn.Click += BuscarItinerarioBtn_Click;
            // 
            // VerDetallesBtn
            // 
            VerDetallesBtn.Location = new Point(13, 159);
            VerDetallesBtn.Margin = new Padding(3, 4, 3, 4);
            VerDetallesBtn.Name = "VerDetallesBtn";
            VerDetallesBtn.Size = new Size(147, 44);
            VerDetallesBtn.TabIndex = 5;
            VerDetallesBtn.Text = "Ver detalles";
            VerDetallesBtn.UseVisualStyleBackColor = true;
            VerDetallesBtn.Click += VerDetallesBtn_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ConfirmarReservaButton);
            groupBox1.Controls.Add(RealizarReservaButton);
            groupBox1.Controls.Add(RealizarPrereservaButton);
            groupBox1.Controls.Add(ItinerarioListView);
            groupBox1.Controls.Add(BuscarItinerarioBtn);
            groupBox1.Controls.Add(VerDetallesBtn);
            groupBox1.Controls.Add(txtBuscarItinerario);
            groupBox1.Controls.Add(lblBuscarNumeroItinerario);
            groupBox1.Location = new Point(11, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(687, 216);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            // 
            // RealizarReservaButton
            // 
            RealizarReservaButton.Location = new Point(337, 159);
            RealizarReservaButton.Margin = new Padding(3, 4, 3, 4);
            RealizarReservaButton.Name = "RealizarReservaButton";
            RealizarReservaButton.Size = new Size(165, 44);
            RealizarReservaButton.TabIndex = 44;
            RealizarReservaButton.Text = "Realizar reserva";
            RealizarReservaButton.UseVisualStyleBackColor = true;
            RealizarReservaButton.Click += RealizarReservaButton_Click;
            // 
            // RealizarPrereservaButton
            // 
            RealizarPrereservaButton.Location = new Point(166, 159);
            RealizarPrereservaButton.Margin = new Padding(3, 4, 3, 4);
            RealizarPrereservaButton.Name = "RealizarPrereservaButton";
            RealizarPrereservaButton.Size = new Size(165, 44);
            RealizarPrereservaButton.TabIndex = 43;
            RealizarPrereservaButton.Text = "Realizar prereserva";
            RealizarPrereservaButton.UseVisualStyleBackColor = true;
            RealizarPrereservaButton.Click += RealizarPrereservaButton_Click;
            // 
            // ConfirmarReservaButton
            // 
            ConfirmarReservaButton.Location = new Point(508, 159);
            ConfirmarReservaButton.Margin = new Padding(3, 4, 3, 4);
            ConfirmarReservaButton.Name = "ConfirmarReservaButton";
            ConfirmarReservaButton.Size = new Size(165, 44);
            ConfirmarReservaButton.TabIndex = 45;
            ConfirmarReservaButton.Text = "Confirmar reserva";
            ConfirmarReservaButton.UseVisualStyleBackColor = true;
            ConfirmarReservaButton.Click += ConfirmarReservaButton_Click;
            // 
            // BusquedaItinerarioForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(711, 231);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "BusquedaItinerarioForm";
            Text = "Buscar Itinerario";
            Load += BusquedaItinerarioForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListView ItinerarioListView;
        private Label lblBuscarNumeroItinerario;
        private TextBox txtBuscarItinerario;
        private Button BuscarItinerarioBtn;
        private ColumnHeader fechaCreacionItinerarioHeader;
        private ColumnHeader CotizacionHeader;
        private Button VerDetallesBtn;
        private GroupBox groupBox1;
        private ColumnHeader EstadoItinerarioHeader;
        private Button RealizarPrereservaButton;
        private ColumnHeader PagoHeader;
        private Button RealizarReservaButton;
        private Button ConfirmarReservaButton;
    }
}