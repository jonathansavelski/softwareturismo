

namespace grupo3.prototipos.CAI
{
    partial class HotelesForm
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
            HotelesDisponiblesGroupBox = new GroupBox();
            label5 = new Label();
            AñadirAlItinerarioHotelesButton = new Button();
            lblHotelesDisponibles = new Label();
            HotelesListView = new ListView();
            CodigoHotelHeader = new ColumnHeader();
            NombreHeader = new ColumnHeader();
            CiudadHeader = new ColumnHeader();
            DireccionHeader = new ColumnHeader();
            CalificacionHeader = new ColumnHeader();
            NombreHabitacionHeader = new ColumnHeader();
            TarifaPorDiaHeader = new ColumnHeader();
            CapacidadTotalHeader = new ColumnHeader();
            MaximoAdultosHeader = new ColumnHeader();
            MaximoMenoresHeader = new ColumnHeader();
            MaximoInfantesHeader = new ColumnHeader();
            CodigoHabitacionHeader = new ColumnHeader();
            FechaDisponibilidadHeader = new ColumnHeader();
            CantidadDisponibleHeader = new ColumnHeader();
            button1 = new Button();
            lblServiciosExtra = new Label();
            lblDisponibilidad = new Label();
            ServiciosExtraListView = new ListView();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            DisponibilidadListView = new ListView();
            Nombre = new ColumnHeader();
            Tarifa = new ColumnHeader();
            Capacidad = new ColumnHeader();
            Adultos = new ColumnHeader();
            Menores = new ColumnHeader();
            Infantes = new ColumnHeader();
            CheckIn = new ColumnHeader();
            CheckOut = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            FechaDesdeHeader = new ColumnHeader();
            FechaHastaHeader = new ColumnHeader();
            DisponibilidadHeader = new ColumnHeader();
            lblTituloHoteles = new Label();
            grpFiltrosHotel = new GroupBox();
            nudAdultoHotel = new NumericUpDown();
            dtpFinHotel = new DateTimePicker();
            lblAdultoHotel = new Label();
            BuscarHotelButton = new Button();
            CiudadHotel = new Label();
            lblInfanteHotel = new Label();
            lblCantidadPasajeroHotel = new Label();
            nudMenorHotel = new NumericUpDown();
            txtOrigenHotel = new TextBox();
            nudInfanteHotel = new NumericUpDown();
            lblRangoHotel = new Label();
            lblMenorHotel = new Label();
            dtpInicioHotel = new DateTimePicker();
            HotelesDisponiblesGroupBox.SuspendLayout();
            grpFiltrosHotel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudAdultoHotel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMenorHotel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudInfanteHotel).BeginInit();
            SuspendLayout();
            // 
            // HotelesDisponiblesGroupBox
            // 
            HotelesDisponiblesGroupBox.Controls.Add(label5);
            HotelesDisponiblesGroupBox.Controls.Add(AñadirAlItinerarioHotelesButton);
            HotelesDisponiblesGroupBox.Controls.Add(lblHotelesDisponibles);
            HotelesDisponiblesGroupBox.Controls.Add(HotelesListView);
            HotelesDisponiblesGroupBox.Location = new Point(14, 137);
            HotelesDisponiblesGroupBox.Margin = new Padding(3, 4, 3, 4);
            HotelesDisponiblesGroupBox.Name = "HotelesDisponiblesGroupBox";
            HotelesDisponiblesGroupBox.Padding = new Padding(3, 4, 3, 4);
            HotelesDisponiblesGroupBox.Size = new Size(1515, 319);
            HotelesDisponiblesGroupBox.TabIndex = 5;
            HotelesDisponiblesGroupBox.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(153, 19);
            label5.Name = "label5";
            label5.Size = new Size(165, 20);
            label5.TabIndex = 22;
            label5.Text = "(multiselect disponible)";
            // 
            // AñadirAlItinerarioHotelesButton
            // 
            AñadirAlItinerarioHotelesButton.Location = new Point(14, 261);
            AñadirAlItinerarioHotelesButton.Margin = new Padding(3, 4, 3, 4);
            AñadirAlItinerarioHotelesButton.Name = "AñadirAlItinerarioHotelesButton";
            AñadirAlItinerarioHotelesButton.Size = new Size(155, 39);
            AñadirAlItinerarioHotelesButton.TabIndex = 18;
            AñadirAlItinerarioHotelesButton.Text = "Añadir a itinerario";
            AñadirAlItinerarioHotelesButton.UseVisualStyleBackColor = true;
            AñadirAlItinerarioHotelesButton.Click += AñadirAlItinerarioHotelButton_Click;
            // 
            // lblHotelesDisponibles
            // 
            lblHotelesDisponibles.AutoSize = true;
            lblHotelesDisponibles.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblHotelesDisponibles.Location = new Point(11, 19);
            lblHotelesDisponibles.Name = "lblHotelesDisponibles";
            lblHotelesDisponibles.Size = new Size(145, 20);
            lblHotelesDisponibles.TabIndex = 21;
            lblHotelesDisponibles.Text = "Hoteles disponibles";
            // 
            // HotelesListView
            // 
            HotelesListView.Columns.AddRange(new ColumnHeader[] { CodigoHotelHeader, NombreHeader, CiudadHeader, DireccionHeader, CalificacionHeader, NombreHabitacionHeader, TarifaPorDiaHeader, CapacidadTotalHeader, MaximoAdultosHeader, MaximoMenoresHeader, MaximoInfantesHeader, CodigoHabitacionHeader, FechaDisponibilidadHeader, CantidadDisponibleHeader });
            HotelesListView.FullRowSelect = true;
            HotelesListView.GridLines = true;
            HotelesListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            HotelesListView.Location = new Point(13, 52);
            HotelesListView.Margin = new Padding(3, 4, 3, 4);
            HotelesListView.Name = "HotelesListView";
            HotelesListView.Size = new Size(1479, 201);
            HotelesListView.TabIndex = 0;
            HotelesListView.UseCompatibleStateImageBehavior = false;
            HotelesListView.View = View.Details;
            HotelesListView.SelectedIndexChanged += HotelesListView_SelectedIndexChanged;
            // 
            // CodigoHotelHeader
            // 
            CodigoHotelHeader.Text = "Código hotel";
            CodigoHotelHeader.Width = 100;
            // 
            // NombreHeader
            // 
            NombreHeader.Text = "Nombre hotel";
            NombreHeader.TextAlign = HorizontalAlignment.Center;
            NombreHeader.Width = 115;
            // 
            // CiudadHeader
            // 
            CiudadHeader.Text = "Ciudad";
            CiudadHeader.TextAlign = HorizontalAlignment.Center;
            CiudadHeader.Width = 105;
            // 
            // DireccionHeader
            // 
            DireccionHeader.Text = "Dirección hotel";
            DireccionHeader.TextAlign = HorizontalAlignment.Center;
            DireccionHeader.Width = 115;
            // 
            // CalificacionHeader
            // 
            CalificacionHeader.Text = "Calificación";
            CalificacionHeader.TextAlign = HorizontalAlignment.Center;
            CalificacionHeader.Width = 100;
            // 
            // NombreHabitacionHeader
            // 
            NombreHabitacionHeader.Text = "Nombre habitación";
            NombreHabitacionHeader.TextAlign = HorizontalAlignment.Center;
            NombreHabitacionHeader.Width = 145;
            // 
            // TarifaPorDiaHeader
            // 
            TarifaPorDiaHeader.Text = "Tarifa por día";
            TarifaPorDiaHeader.TextAlign = HorizontalAlignment.Center;
            TarifaPorDiaHeader.Width = 100;
            // 
            // CapacidadTotalHeader
            // 
            CapacidadTotalHeader.Text = "Capacidad habitación";
            CapacidadTotalHeader.TextAlign = HorizontalAlignment.Center;
            CapacidadTotalHeader.Width = 160;
            // 
            // MaximoAdultosHeader
            // 
            MaximoAdultosHeader.Text = "Cantidad máx. adultos";
            MaximoAdultosHeader.TextAlign = HorizontalAlignment.Center;
            MaximoAdultosHeader.Width = 175;
            // 
            // MaximoMenoresHeader
            // 
            MaximoMenoresHeader.Text = "Cantidad máx. menores";
            MaximoMenoresHeader.TextAlign = HorizontalAlignment.Center;
            MaximoMenoresHeader.Width = 175;
            // 
            // MaximoInfantesHeader
            // 
            MaximoInfantesHeader.Text = "Cantidad máx. infantes";
            MaximoInfantesHeader.TextAlign = HorizontalAlignment.Center;
            MaximoInfantesHeader.Width = 170;
            // 
            // CodigoHabitacionHeader
            // 
            CodigoHabitacionHeader.Text = "Código habitación";
            CodigoHabitacionHeader.Width = 120;
            // 
            // FechaDisponibilidadHeader
            // 
            FechaDisponibilidadHeader.Text = "Fecha Disponibilidad";
            FechaDisponibilidadHeader.TextAlign = HorizontalAlignment.Center;
            FechaDisponibilidadHeader.Width = 155;
            // 
            // CantidadDisponibleHeader
            // 
            CantidadDisponibleHeader.Text = "Cantidad disponible s/fecha";
            CantidadDisponibleHeader.TextAlign = HorizontalAlignment.Center;
            CantidadDisponibleHeader.Width = 230;
            // 
            // button1
            // 
            button1.Location = new Point(746, 262);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(82, 22);
            button1.TabIndex = 11;
            button1.Text = "Aplicar";
            button1.UseVisualStyleBackColor = true;
            // 
            // lblServiciosExtra
            // 
            lblServiciosExtra.AutoSize = true;
            lblServiciosExtra.Location = new Point(6, 159);
            lblServiciosExtra.Name = "lblServiciosExtra";
            lblServiciosExtra.Size = new Size(85, 15);
            lblServiciosExtra.TabIndex = 5;
            lblServiciosExtra.Text = "Servicios extra:";
            // 
            // lblDisponibilidad
            // 
            lblDisponibilidad.AutoSize = true;
            lblDisponibilidad.Location = new Point(8, 30);
            lblDisponibilidad.Name = "lblDisponibilidad";
            lblDisponibilidad.Size = new Size(83, 15);
            lblDisponibilidad.TabIndex = 4;
            lblDisponibilidad.Text = "Disponibilidad";
            // 
            // ServiciosExtraListView
            // 
            ServiciosExtraListView.Columns.AddRange(new ColumnHeader[] { columnHeader7, columnHeader8, columnHeader9, columnHeader10 });
            ServiciosExtraListView.Location = new Point(8, 187);
            ServiciosExtraListView.Name = "ServiciosExtraListView";
            ServiciosExtraListView.Size = new Size(712, 97);
            ServiciosExtraListView.TabIndex = 2;
            ServiciosExtraListView.UseCompatibleStateImageBehavior = false;
            ServiciosExtraListView.View = View.Details;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Código";
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Descripción";
            columnHeader8.Width = 130;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Tarifa";
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Por pasajero";
            columnHeader10.Width = 80;
            // 
            // DisponibilidadListView
            // 
            DisponibilidadListView.Columns.AddRange(new ColumnHeader[] { Nombre, Tarifa, Capacidad, Adultos, Menores, Infantes, CheckIn, CheckOut, columnHeader6 });
            DisponibilidadListView.Location = new Point(8, 48);
            DisponibilidadListView.Name = "DisponibilidadListView";
            DisponibilidadListView.Size = new Size(712, 93);
            DisponibilidadListView.TabIndex = 1;
            DisponibilidadListView.UseCompatibleStateImageBehavior = false;
            DisponibilidadListView.View = View.Details;
            // 
            // Nombre
            // 
            Nombre.Text = "Nombre";
            Nombre.Width = 100;
            // 
            // Tarifa
            // 
            Tarifa.Text = "Tarifa";
            // 
            // Capacidad
            // 
            Capacidad.Text = "Capacidad";
            Capacidad.Width = 70;
            // 
            // Adultos
            // 
            Adultos.Text = "Adultos";
            // 
            // Menores
            // 
            Menores.Text = "Menores";
            // 
            // Infantes
            // 
            Infantes.Text = "Infantes";
            // 
            // CheckIn
            // 
            CheckIn.Text = "Check in";
            CheckIn.Width = 95;
            // 
            // CheckOut
            // 
            CheckOut.Text = "Check out";
            CheckOut.Width = 95;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Disponibilidad";
            columnHeader6.Width = 90;
            // 
            // FechaDesdeHeader
            // 
            FechaDesdeHeader.Text = "Fecha Desde";
            FechaDesdeHeader.TextAlign = HorizontalAlignment.Center;
            FechaDesdeHeader.Width = 120;
            // 
            // FechaHastaHeader
            // 
            FechaHastaHeader.Text = "Fecha Hasta";
            FechaHastaHeader.TextAlign = HorizontalAlignment.Center;
            FechaHastaHeader.Width = 120;
            // 
            // DisponibilidadHeader
            // 
            DisponibilidadHeader.Text = "Disponibilidad";
            DisponibilidadHeader.TextAlign = HorizontalAlignment.Center;
            DisponibilidadHeader.Width = 120;
            // 
            // lblTituloHoteles
            // 
            lblTituloHoteles.AutoSize = true;
            lblTituloHoteles.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblTituloHoteles.Location = new Point(7, 19);
            lblTituloHoteles.Name = "lblTituloHoteles";
            lblTituloHoteles.Size = new Size(237, 20);
            lblTituloHoteles.TabIndex = 1;
            lblTituloHoteles.Text = "Búsqueda de hoteles disponibles";
            // 
            // grpFiltrosHotel
            // 
            grpFiltrosHotel.Controls.Add(nudAdultoHotel);
            grpFiltrosHotel.Controls.Add(dtpFinHotel);
            grpFiltrosHotel.Controls.Add(lblAdultoHotel);
            grpFiltrosHotel.Controls.Add(BuscarHotelButton);
            grpFiltrosHotel.Controls.Add(CiudadHotel);
            grpFiltrosHotel.Controls.Add(lblInfanteHotel);
            grpFiltrosHotel.Controls.Add(lblCantidadPasajeroHotel);
            grpFiltrosHotel.Controls.Add(nudMenorHotel);
            grpFiltrosHotel.Controls.Add(txtOrigenHotel);
            grpFiltrosHotel.Controls.Add(nudInfanteHotel);
            grpFiltrosHotel.Controls.Add(lblRangoHotel);
            grpFiltrosHotel.Controls.Add(lblMenorHotel);
            grpFiltrosHotel.Controls.Add(dtpInicioHotel);
            grpFiltrosHotel.Controls.Add(lblTituloHoteles);
            grpFiltrosHotel.Location = new Point(14, 1);
            grpFiltrosHotel.Margin = new Padding(3, 4, 3, 4);
            grpFiltrosHotel.Name = "grpFiltrosHotel";
            grpFiltrosHotel.Padding = new Padding(3, 4, 3, 4);
            grpFiltrosHotel.Size = new Size(1515, 129);
            grpFiltrosHotel.TabIndex = 22;
            grpFiltrosHotel.TabStop = false;
            // 
            // nudAdultoHotel
            // 
            nudAdultoHotel.Location = new Point(530, 83);
            nudAdultoHotel.Name = "nudAdultoHotel";
            nudAdultoHotel.Size = new Size(43, 27);
            nudAdultoHotel.TabIndex = 31;
            // 
            // dtpFinHotel
            // 
            dtpFinHotel.Format = DateTimePickerFormat.Short;
            dtpFinHotel.Location = new Point(310, 83);
            dtpFinHotel.Name = "dtpFinHotel";
            dtpFinHotel.Size = new Size(121, 27);
            dtpFinHotel.TabIndex = 27;
            // 
            // lblAdultoHotel
            // 
            lblAdultoHotel.AutoSize = true;
            lblAdultoHotel.Location = new Point(461, 87);
            lblAdultoHotel.Name = "lblAdultoHotel";
            lblAdultoHotel.Size = new Size(63, 20);
            lblAdultoHotel.TabIndex = 30;
            lblAdultoHotel.Text = "Adultos:";
            // 
            // BuscarHotelButton
            // 
            BuscarHotelButton.Location = new Point(889, 68);
            BuscarHotelButton.Name = "BuscarHotelButton";
            BuscarHotelButton.Size = new Size(155, 39);
            BuscarHotelButton.TabIndex = 21;
            BuscarHotelButton.Text = "Buscar hoteles";
            BuscarHotelButton.UseVisualStyleBackColor = true;
            BuscarHotelButton.Click += BuscarHotelButton_Click;
            // 
            // CiudadHotel
            // 
            CiudadHotel.AutoSize = true;
            CiudadHotel.Location = new Point(11, 51);
            CiudadHotel.Name = "CiudadHotel";
            CiudadHotel.Size = new Size(56, 20);
            CiudadHotel.TabIndex = 24;
            CiudadHotel.Text = "Ciudad";
            // 
            // lblInfanteHotel
            // 
            lblInfanteHotel.AutoSize = true;
            lblInfanteHotel.Location = new Point(592, 87);
            lblInfanteHotel.Name = "lblInfanteHotel";
            lblInfanteHotel.Size = new Size(64, 20);
            lblInfanteHotel.TabIndex = 29;
            lblInfanteHotel.Text = "Infantes:";
            // 
            // lblCantidadPasajeroHotel
            // 
            lblCantidadPasajeroHotel.AutoSize = true;
            lblCantidadPasajeroHotel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblCantidadPasajeroHotel.Location = new Point(461, 51);
            lblCantidadPasajeroHotel.Name = "lblCantidadPasajeroHotel";
            lblCantidadPasajeroHotel.Size = new Size(157, 20);
            lblCantidadPasajeroHotel.TabIndex = 28;
            lblCantidadPasajeroHotel.Text = "Cantidad de pasajeros";
            // 
            // nudMenorHotel
            // 
            nudMenorHotel.Location = new Point(802, 83);
            nudMenorHotel.Name = "nudMenorHotel";
            nudMenorHotel.Size = new Size(43, 27);
            nudMenorHotel.TabIndex = 20;
            // 
            // txtOrigenHotel
            // 
            txtOrigenHotel.Location = new Point(13, 83);
            txtOrigenHotel.Name = "txtOrigenHotel";
            txtOrigenHotel.Size = new Size(125, 27);
            txtOrigenHotel.TabIndex = 23;
            // 
            // nudInfanteHotel
            // 
            nudInfanteHotel.Location = new Point(662, 83);
            nudInfanteHotel.Name = "nudInfanteHotel";
            nudInfanteHotel.Size = new Size(43, 27);
            nudInfanteHotel.TabIndex = 19;
            // 
            // lblRangoHotel
            // 
            lblRangoHotel.AutoSize = true;
            lblRangoHotel.Location = new Point(168, 51);
            lblRangoHotel.Name = "lblRangoHotel";
            lblRangoHotel.Size = new Size(121, 20);
            lblRangoHotel.TabIndex = 22;
            lblRangoHotel.Text = "Rango de Fechas";
            // 
            // lblMenorHotel
            // 
            lblMenorHotel.AutoSize = true;
            lblMenorHotel.Location = new Point(727, 87);
            lblMenorHotel.Name = "lblMenorHotel";
            lblMenorHotel.Size = new Size(69, 20);
            lblMenorHotel.TabIndex = 13;
            lblMenorHotel.Text = "Menores:";
            // 
            // dtpInicioHotel
            // 
            dtpInicioHotel.Format = DateTimePickerFormat.Short;
            dtpInicioHotel.Location = new Point(171, 83);
            dtpInicioHotel.Name = "dtpInicioHotel";
            dtpInicioHotel.Size = new Size(121, 27);
            dtpInicioHotel.TabIndex = 20;
            // 
            // HotelesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1541, 469);
            Controls.Add(grpFiltrosHotel);
            Controls.Add(HotelesDisponiblesGroupBox);
            Margin = new Padding(3, 4, 3, 4);
            Name = "HotelesForm";
            Text = "HotelesForm";
            Load += HotelesForm_Load;
            HotelesDisponiblesGroupBox.ResumeLayout(false);
            HotelesDisponiblesGroupBox.PerformLayout();
            grpFiltrosHotel.ResumeLayout(false);
            grpFiltrosHotel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudAdultoHotel).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMenorHotel).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudInfanteHotel).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox HotelesDisponiblesGroupBox;
        private ListView HotelesListView;
        private ColumnHeader CodigoHotelHeader;
        private ColumnHeader NombreHeader;
        private ColumnHeader CiudadHeader;
        private ColumnHeader DireccionHeader;
        private ColumnHeader CalificacionHeader;
        private Button button1;
        private Label lblServiciosExtra;
        private Label lblDisponibilidad;
        private Label lblParadas;
        private ListView ServiciosExtraListView;
        private ListView DisponibilidadListView;
        private ListView ParadasListView;
        private ColumnHeader Nombre;
        private ColumnHeader Tarifa;
        private ColumnHeader Capacidad;
        private ColumnHeader Adultos;
        private ColumnHeader Menores;
        private ColumnHeader Infantes;
        private ColumnHeader CheckIn;
        private ColumnHeader CheckOut;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader ClaseTarifaHeader;
        private ColumnHeader ItinerarioTarifaHeader;
        private ColumnHeader TipoPasajeroTarifaHeader;
        private ColumnHeader BaseTarifaHeader;
        private ColumnHeader ImpuestosTarifaHeader;
        private ColumnHeader ComisionTarifaHeader;
        private ColumnHeader FechaDesdeHeader;
        private ColumnHeader FechaHastaHeader;
        private ColumnHeader DisponibilidadHeader;
        private ColumnHeader AeropuertoParadaHeader;
        private ColumnHeader TiempoParadaHeader;
        private Label lblTituloHoteles;
        private GroupBox grpFiltrosHotel;
        private DateTimePicker dtpFinHotel;
        private Label lblDestinoHotel;
        private TextBox txtDestinoHotel;
        private Label CiudadHotel;
        private TextBox txtOrigenHotel;
        private Button BuscarHotelButton;
        private Label lblRangoHotel;
        private DateTimePicker dtpInicioHotel;
        private Label lblHotelesDisponibles;
        private ColumnHeader NombreHabitacionHeader;
        private ColumnHeader TarifaPorDiaHeader;
        private Button AñadirAlItinerarioHotelesButton;
        private NumericUpDown nudMenorHotel;
        private NumericUpDown nudInfanteHotel;
        private NumericUpDown nudAdultoHotel;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label lblMenorHotel;
        private Label lblCantidadPasajeroHotel;
        private Label lblAdultoHotel;
        private Label lblInfanteHotel;
        private ColumnHeader CapacidadTotalHeader;
        private ColumnHeader MaximoAdultosHeader;
        private ColumnHeader MaximoMenoresHeader;
        private ColumnHeader MaximoInfantesHeader;
        private ColumnHeader FechaDisponibilidadHeader;
        private ColumnHeader CantidadDisponibleHeader;
        private ColumnHeader CodigoHabitacionHeader;
        private Label label5;
    }
}