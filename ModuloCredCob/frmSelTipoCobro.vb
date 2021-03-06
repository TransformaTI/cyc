Imports System.Data.SqlClient

Public Class frmSelTipoCobro
    Inherits System.Windows.Forms.Form
    Private Titulo As String = "Captura de cobranza"
    Private _Consecutivo As Integer
    Public Cobro As SigaMetClasses.sCobro
    Public ImporteTotalCobro As Decimal = 0
    Private _TipoCobro As SigaMetClasses.Enumeradores.enumTipoCobro
    Private _TipoMovimientoCaja As Byte
    Private _SoloDocumentosCartera As Boolean
    Private _CapturaDetalle As Boolean
    Private _ListaCobros As ListBox
    Private _RelacionCobranza As ArrayList
    Private _EsRelacionCobranza As Boolean
    Private _CargaNotaIngreso As Boolean

    'Control de cheques posfechados
    Private _ChequePosfechado As Boolean

    Public ReadOnly Property Posfechado() As Boolean
        Get
            Return _ChequePosfechado
        End Get
    End Property

    'Constructor para la captura normal de cobranza
    Public Sub New(ByVal intConsecutivo As Integer, _
                   ByVal TipoMovimientoCaja As Byte, _
                   ByVal ListaCobros As ListBox, _
          Optional ByVal SoloDocumentosCartera As Boolean = True, _
          Optional ByVal CapturaDetalle As Boolean = True)
        MyBase.New()
        InitializeComponent()
        If CapturaEfectivoVales = True Then
            btnAceptarEfectivoVales.Enabled = False
        End If
        If CapturaMixtaEfectivoVales = True Then
            'btnAceptarEfectivo.Enabled = False
            'btnAceptarVale.Enabled = False
        End If
        _Consecutivo = intConsecutivo
        _TipoMovimientoCaja = TipoMovimientoCaja
        _SoloDocumentosCartera = SoloDocumentosCartera
        _CapturaDetalle = CapturaDetalle
        _ListaCobros = ListaCobros

    End Sub

    'Constructor para las Relaciones de Cobranza
    Public Sub New(ByVal intConsecutivo As Integer, _
                   ByVal ListaCobros As ListBox, _
                   ByVal RelacionCobranza As ArrayList, _
                   ByVal TipoMovimientoCaja As Byte)
        MyBase.New()
        InitializeComponent()
        If CapturaEfectivoVales = True Then
            btnAceptarEfectivoVales.Enabled = False
        End If
        _Consecutivo = intConsecutivo
        _TipoMovimientoCaja = TipoMovimientoCaja
        _SoloDocumentosCartera = True
        _CapturaDetalle = True
        _ListaCobros = ListaCobros
        _RelacionCobranza = RelacionCobranza
        _EsRelacionCobranza = True
        tabTipoCobro.SelectedTab = tbChequeFicha
        txtDocumento.Focus()
        txtDocumento.SelectAll()

    End Sub

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub



    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents tabTipoCobro As System.Windows.Forms.TabControl
    Friend WithEvents dtpFechaCheque As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblObservaciones As ControlesBase.LabelBase
    Friend WithEvents lblNoCheque As ControlesBase.LabelBase
    Friend WithEvents lblFechaCheque As ControlesBase.LabelBase
    Friend WithEvents lblNoCuenta As ControlesBase.LabelBase
    Friend WithEvents lblImporte As ControlesBase.LabelBase
    Friend WithEvents lblCliente As ControlesBase.LabelBase
    Friend WithEvents tbEfectivoVales As System.Windows.Forms.TabPage
    Friend WithEvents btnAceptarEfectivoVales As ControlesBase.BotonBase
    Friend WithEvents grpEfectivoVales As System.Windows.Forms.GroupBox
    Friend WithEvents lblTotalEfectivoVales As ControlesBase.LabelBase
    Friend WithEvents imgLista As System.Windows.Forms.ImageList
    Friend WithEvents tbTarjetaCredito As System.Windows.Forms.TabPage
    Friend WithEvents grpTarjetaCredito As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As ControlesBase.LabelBase
    Friend WithEvents LabelBase1 As ControlesBase.LabelBase
    Friend WithEvents LabelBase3 As ControlesBase.LabelBase
    Friend WithEvents btnAceptarTarjetaCredito As ControlesBase.BotonBase
    Friend WithEvents lblTarjetaCredito As System.Windows.Forms.Label
    Friend WithEvents lblTitular As System.Windows.Forms.Label
    Friend WithEvents lblTipoTarjetaCredito As System.Windows.Forms.Label
    Friend WithEvents LabelBase4 As ControlesBase.LabelBase
    Friend WithEvents lblVigencia As System.Windows.Forms.Label
    Friend WithEvents LabelBase5 As ControlesBase.LabelBase
    Friend WithEvents btnBuscarClienteTC As System.Windows.Forms.Button
    Friend WithEvents LabelBase6 As ControlesBase.LabelBase
    Friend WithEvents lblBancoNombre As System.Windows.Forms.Label
    Friend WithEvents LabelBase7 As ControlesBase.LabelBase
    Friend WithEvents lblClienteNombre As System.Windows.Forms.Label
    Friend WithEvents lblBanco As System.Windows.Forms.Label
    Friend WithEvents ComboBanco As SigaMetClasses.Combos.ComboBanco
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalEfectivoVales As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtNumeroCuenta As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtClienteCheque As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtClienteTC As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtImporteTC As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents btnAceptarChequeFicha As ControlesBase.BotonBase
    Friend WithEvents tbChequeFicha As System.Windows.Forms.TabPage
    Friend WithEvents grpChequeFicha As System.Windows.Forms.GroupBox
    Friend WithEvents rbCheque As System.Windows.Forms.RadioButton
    Friend WithEvents rbFicha As System.Windows.Forms.RadioButton
    Friend WithEvents txtImporteDocumento As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents rbNotaCredito As System.Windows.Forms.RadioButton
    Friend WithEvents rbNotaIngreso As System.Windows.Forms.RadioButton
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents btnLeerCodigo As System.Windows.Forms.Button
    Friend WithEvents LabelBase8 As ControlesBase.LabelBase
    Friend WithEvents ttMensaje As System.Windows.Forms.ToolTip
    Friend WithEvents chkCargarNI As System.Windows.Forms.CheckBox
    Friend WithEvents txtDocumento As System.Windows.Forms.TextBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents rbTransferencia As System.Windows.Forms.RadioButton
    Friend WithEvents lblCtaDestino As ControlesBase.LabelBase
    Friend WithEvents ComboBancoOrigen As SigaMetClasses.Combos.ComboBanco
    Friend WithEvents lblBancoDestino As ControlesBase.LabelBase
    Friend WithEvents lblBancoOrigen As ControlesBase.LabelBase
    Friend WithEvents txtNumeroCuentaOrigen As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents tbSaldoAFavor As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents grpOrigen As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblSFCliente As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents btnSFBuscar As System.Windows.Forms.Button
    Friend WithEvents txtSFA�oAtt As System.Windows.Forms.TextBox
    Friend WithEvents txtSFFolioAtt As System.Windows.Forms.TextBox
    Friend WithEvents txtSFCliente As System.Windows.Forms.TextBox
    Friend WithEvents txtSFClave As System.Windows.Forms.TextBox
    Friend WithEvents lblSFImporte As System.Windows.Forms.Label
    Friend WithEvents lblSaldoAFavorNombre As System.Windows.Forms.Label
    Friend WithEvents btnAceptarSF As ControlesBase.BotonBase
    Friend WithEvents lblSFCobro As System.Windows.Forms.Label
    Friend WithEvents lblSFTipo As System.Windows.Forms.Label
    Friend WithEvents lblSFMovimientoOrigen As System.Windows.Forms.Label
    Friend WithEvents lblSFA�oCobro As System.Windows.Forms.Label
    'Friend WithEvents cboNumeroCuenta As System.Windows.Forms.ComboBox
    Friend WithEvents cboNumeroCuenta As SigaMetClasses.Controles.cboNumeroEntero
    Friend WithEvents chkCapturaTPV As System.Windows.Forms.CheckBox
    Friend WithEvents lblTxtTarjeta As ControlesBase.LabelBase
    Friend WithEvents txtNumeroTarjeta As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents comboBancoTDC As SigaMetClasses.Combos.ComboBanco
    Friend WithEvents ComboBanco1 As SigaMetClasses.Combos.ComboBanco
    Friend WithEvents btnBusquedaCliente As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSelTipoCobro))
        Me.tabTipoCobro = New System.Windows.Forms.TabControl()
        Me.tbEfectivoVales = New System.Windows.Forms.TabPage()
        Me.grpEfectivoVales = New System.Windows.Forms.GroupBox()
        Me.txtTotalEfectivoVales = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.lblTotalEfectivoVales = New ControlesBase.LabelBase()
        Me.btnAceptarEfectivoVales = New ControlesBase.BotonBase()
        Me.tbTarjetaCredito = New System.Windows.Forms.TabPage()
        Me.chkCapturaTPV = New System.Windows.Forms.CheckBox()
        Me.btnAceptarTarjetaCredito = New ControlesBase.BotonBase()
        Me.grpTarjetaCredito = New System.Windows.Forms.GroupBox()
        Me.txtImporteTC = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtClienteTC = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.lblBanco = New System.Windows.Forms.Label()
        Me.LabelBase7 = New ControlesBase.LabelBase()
        Me.lblClienteNombre = New System.Windows.Forms.Label()
        Me.LabelBase6 = New ControlesBase.LabelBase()
        Me.lblVigencia = New System.Windows.Forms.Label()
        Me.LabelBase5 = New ControlesBase.LabelBase()
        Me.lblTipoTarjetaCredito = New System.Windows.Forms.Label()
        Me.LabelBase4 = New ControlesBase.LabelBase()
        Me.lblBancoNombre = New System.Windows.Forms.Label()
        Me.LabelBase3 = New ControlesBase.LabelBase()
        Me.lblTarjetaCredito = New System.Windows.Forms.Label()
        Me.lblTxtTarjeta = New ControlesBase.LabelBase()
        Me.LabelBase1 = New ControlesBase.LabelBase()
        Me.Label20 = New ControlesBase.LabelBase()
        Me.lblTitular = New System.Windows.Forms.Label()
        Me.btnBuscarClienteTC = New System.Windows.Forms.Button()
        Me.txtNumeroTarjeta = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.comboBancoTDC = New SigaMetClasses.Combos.ComboBanco()
        Me.tbChequeFicha = New System.Windows.Forms.TabPage()
        Me.rbTransferencia = New System.Windows.Forms.RadioButton()
        Me.chkCargarNI = New System.Windows.Forms.CheckBox()
        Me.LabelBase8 = New ControlesBase.LabelBase()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.rbNotaIngreso = New System.Windows.Forms.RadioButton()
        Me.btnAceptarChequeFicha = New ControlesBase.BotonBase()
        Me.grpChequeFicha = New System.Windows.Forms.GroupBox()
        Me.cboNumeroCuenta = New SigaMetClasses.Controles.cboNumeroEntero()
        Me.txtDocumento = New System.Windows.Forms.TextBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.txtImporteDocumento = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtClienteCheque = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.txtNumeroCuenta = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.ComboBanco = New SigaMetClasses.Combos.ComboBanco()
        Me.lblBancoDestino = New ControlesBase.LabelBase()
        Me.lblObservaciones = New ControlesBase.LabelBase()
        Me.dtpFechaCheque = New System.Windows.Forms.DateTimePicker()
        Me.lblNoCheque = New ControlesBase.LabelBase()
        Me.lblFechaCheque = New ControlesBase.LabelBase()
        Me.lblNoCuenta = New ControlesBase.LabelBase()
        Me.lblImporte = New ControlesBase.LabelBase()
        Me.lblCliente = New ControlesBase.LabelBase()
        Me.lblBancoOrigen = New ControlesBase.LabelBase()
        Me.ComboBancoOrigen = New SigaMetClasses.Combos.ComboBanco()
        Me.txtNumeroCuentaOrigen = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.lblCtaDestino = New ControlesBase.LabelBase()
        Me.rbNotaCredito = New System.Windows.Forms.RadioButton()
        Me.rbFicha = New System.Windows.Forms.RadioButton()
        Me.rbCheque = New System.Windows.Forms.RadioButton()
        Me.btnLeerCodigo = New System.Windows.Forms.Button()
        Me.tbSaldoAFavor = New System.Windows.Forms.TabPage()
        Me.btnAceptarSF = New ControlesBase.BotonBase()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblSFA�oCobro = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblSFImporte = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblSFCobro = New System.Windows.Forms.Label()
        Me.lblSFTipo = New System.Windows.Forms.Label()
        Me.lblSFMovimientoOrigen = New System.Windows.Forms.Label()
        Me.lblSaldoAFavorNombre = New System.Windows.Forms.Label()
        Me.lblSFCliente = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.grpOrigen = New System.Windows.Forms.GroupBox()
        Me.txtSFA�oAtt = New System.Windows.Forms.TextBox()
        Me.btnSFBuscar = New System.Windows.Forms.Button()
        Me.txtSFFolioAtt = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSFCliente = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSFClave = New System.Windows.Forms.TextBox()
        Me.imgLista = New System.Windows.Forms.ImageList(Me.components)
        Me.ttMensaje = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.ComboBanco1 = New SigaMetClasses.Combos.ComboBanco()
        Me.btnBusquedaCliente = New System.Windows.Forms.Button()
        Me.tabTipoCobro.SuspendLayout()
        Me.tbEfectivoVales.SuspendLayout()
        Me.grpEfectivoVales.SuspendLayout()
        Me.tbTarjetaCredito.SuspendLayout()
        Me.grpTarjetaCredito.SuspendLayout()
        Me.tbChequeFicha.SuspendLayout()
        Me.grpChequeFicha.SuspendLayout()
        Me.tbSaldoAFavor.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpOrigen.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabTipoCobro
        '
        Me.tabTipoCobro.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.tabTipoCobro.Controls.AddRange(New System.Windows.Forms.Control() {Me.tbEfectivoVales, Me.tbTarjetaCredito, Me.tbChequeFicha, Me.tbSaldoAFavor})
        Me.tabTipoCobro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabTipoCobro.HotTrack = True
        Me.tabTipoCobro.Multiline = True
        Me.tabTipoCobro.Name = "tabTipoCobro"
        Me.tabTipoCobro.SelectedIndex = 0
        Me.tabTipoCobro.Size = New System.Drawing.Size(474, 396)
        Me.tabTipoCobro.TabIndex = 0
        '
        'tbEfectivoVales
        '
        Me.tbEfectivoVales.BackColor = System.Drawing.SystemColors.Control
        Me.tbEfectivoVales.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpEfectivoVales, Me.btnAceptarEfectivoVales})
        Me.tbEfectivoVales.ImageIndex = 0
        Me.tbEfectivoVales.Location = New System.Drawing.Point(4, 4)
        Me.tbEfectivoVales.Name = "tbEfectivoVales"
        Me.tbEfectivoVales.Size = New System.Drawing.Size(466, 370)
        Me.tbEfectivoVales.TabIndex = 3
        Me.tbEfectivoVales.Text = "Efectivo y / o vales"
        '
        'grpEfectivoVales
        '
        Me.grpEfectivoVales.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtTotalEfectivoVales, Me.lblTotalEfectivoVales})
        Me.grpEfectivoVales.Location = New System.Drawing.Point(48, 138)
        Me.grpEfectivoVales.Name = "grpEfectivoVales"
        Me.grpEfectivoVales.Size = New System.Drawing.Size(272, 48)
        Me.grpEfectivoVales.TabIndex = 32
        Me.grpEfectivoVales.TabStop = False
        Me.grpEfectivoVales.Text = "Datos del efectivo o vales de despensa"
        '
        'txtTotalEfectivoVales
        '
        Me.txtTotalEfectivoVales.Location = New System.Drawing.Point(136, 16)
        Me.txtTotalEfectivoVales.Name = "txtTotalEfectivoVales"
        Me.txtTotalEfectivoVales.Size = New System.Drawing.Size(120, 21)
        Me.txtTotalEfectivoVales.TabIndex = 0
        Me.txtTotalEfectivoVales.Text = ""
        '
        'lblTotalEfectivoVales
        '
        Me.lblTotalEfectivoVales.AutoSize = True
        Me.lblTotalEfectivoVales.Location = New System.Drawing.Point(16, 19)
        Me.lblTotalEfectivoVales.Name = "lblTotalEfectivoVales"
        Me.lblTotalEfectivoVales.Size = New System.Drawing.Size(74, 14)
        Me.lblTotalEfectivoVales.TabIndex = 28
        Me.lblTotalEfectivoVales.Text = "Importe total:"
        '
        'btnAceptarEfectivoVales
        '
        Me.btnAceptarEfectivoVales.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnAceptarEfectivoVales.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptarEfectivoVales.Image = CType(resources.GetObject("btnAceptarEfectivoVales.Image"), System.Drawing.Bitmap)
        Me.btnAceptarEfectivoVales.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptarEfectivoVales.Location = New System.Drawing.Point(368, 150)
        Me.btnAceptarEfectivoVales.Name = "btnAceptarEfectivoVales"
        Me.btnAceptarEfectivoVales.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptarEfectivoVales.TabIndex = 1
        Me.btnAceptarEfectivoVales.Text = "&Aceptar"
        Me.btnAceptarEfectivoVales.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbTarjetaCredito
        '
        Me.tbTarjetaCredito.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkCapturaTPV, Me.btnAceptarTarjetaCredito, Me.grpTarjetaCredito})
        Me.tbTarjetaCredito.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTarjetaCredito.Location = New System.Drawing.Point(4, 4)
        Me.tbTarjetaCredito.Name = "tbTarjetaCredito"
        Me.tbTarjetaCredito.Size = New System.Drawing.Size(466, 370)
        Me.tbTarjetaCredito.TabIndex = 0
        Me.tbTarjetaCredito.Text = "Tarjeta de cr�dito"
        '
        'chkCapturaTPV
        '
        Me.chkCapturaTPV.Location = New System.Drawing.Point(48, 16)
        Me.chkCapturaTPV.Name = "chkCapturaTPV"
        Me.chkCapturaTPV.Size = New System.Drawing.Size(160, 24)
        Me.chkCapturaTPV.TabIndex = 31
        Me.chkCapturaTPV.Text = "Capturar recibo TPV"
        '
        'btnAceptarTarjetaCredito
        '
        Me.btnAceptarTarjetaCredito.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnAceptarTarjetaCredito.Image = CType(resources.GetObject("btnAceptarTarjetaCredito.Image"), System.Drawing.Bitmap)
        Me.btnAceptarTarjetaCredito.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptarTarjetaCredito.Location = New System.Drawing.Point(368, 150)
        Me.btnAceptarTarjetaCredito.Name = "btnAceptarTarjetaCredito"
        Me.btnAceptarTarjetaCredito.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptarTarjetaCredito.TabIndex = 3
        Me.btnAceptarTarjetaCredito.Text = "&Aceptar"
        Me.btnAceptarTarjetaCredito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpTarjetaCredito
        '
        Me.grpTarjetaCredito.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtImporteTC, Me.txtClienteTC, Me.lblBanco, Me.LabelBase7, Me.lblClienteNombre, Me.LabelBase6, Me.lblVigencia, Me.LabelBase5, Me.lblTipoTarjetaCredito, Me.LabelBase4, Me.lblBancoNombre, Me.LabelBase3, Me.lblTarjetaCredito, Me.lblTxtTarjeta, Me.LabelBase1, Me.Label20, Me.lblTitular, Me.btnBuscarClienteTC, Me.txtNumeroTarjeta, Me.comboBancoTDC})
        Me.grpTarjetaCredito.Location = New System.Drawing.Point(48, 48)
        Me.grpTarjetaCredito.Name = "grpTarjetaCredito"
        Me.grpTarjetaCredito.Size = New System.Drawing.Size(280, 253)
        Me.grpTarjetaCredito.TabIndex = 30
        Me.grpTarjetaCredito.TabStop = False
        Me.grpTarjetaCredito.Text = "Datos de la tarjeta de cr�dito"
        '
        'txtImporteTC
        '
        Me.txtImporteTC.Location = New System.Drawing.Point(104, 216)
        Me.txtImporteTC.Name = "txtImporteTC"
        Me.txtImporteTC.Size = New System.Drawing.Size(160, 21)
        Me.txtImporteTC.TabIndex = 4
        Me.txtImporteTC.Text = ""
        '
        'txtClienteTC
        '
        Me.txtClienteTC.Location = New System.Drawing.Point(104, 32)
        Me.txtClienteTC.Name = "txtClienteTC"
        Me.txtClienteTC.TabIndex = 0
        Me.txtClienteTC.Text = ""
        '
        'lblBanco
        '
        Me.lblBanco.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBanco.Location = New System.Drawing.Point(104, 144)
        Me.lblBanco.Name = "lblBanco"
        Me.lblBanco.Size = New System.Drawing.Size(44, 21)
        Me.lblBanco.TabIndex = 42
        Me.lblBanco.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBanco.Visible = False
        '
        'LabelBase7
        '
        Me.LabelBase7.AutoSize = True
        Me.LabelBase7.Location = New System.Drawing.Point(16, 65)
        Me.LabelBase7.Name = "LabelBase7"
        Me.LabelBase7.Size = New System.Drawing.Size(48, 14)
        Me.LabelBase7.TabIndex = 40
        Me.LabelBase7.Text = "Nombre:"
        '
        'lblClienteNombre
        '
        Me.lblClienteNombre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClienteNombre.Location = New System.Drawing.Point(104, 56)
        Me.lblClienteNombre.Name = "lblClienteNombre"
        Me.lblClienteNombre.Size = New System.Drawing.Size(160, 32)
        Me.lblClienteNombre.TabIndex = 41
        Me.lblClienteNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelBase6
        '
        Me.LabelBase6.AutoSize = True
        Me.LabelBase6.Location = New System.Drawing.Point(16, 219)
        Me.LabelBase6.Name = "LabelBase6"
        Me.LabelBase6.Size = New System.Drawing.Size(48, 14)
        Me.LabelBase6.TabIndex = 39
        Me.LabelBase6.Text = "Importe:"
        '
        'lblVigencia
        '
        Me.lblVigencia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblVigencia.Location = New System.Drawing.Point(104, 192)
        Me.lblVigencia.Name = "lblVigencia"
        Me.lblVigencia.Size = New System.Drawing.Size(160, 21)
        Me.lblVigencia.TabIndex = 38
        Me.lblVigencia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelBase5
        '
        Me.LabelBase5.AutoSize = True
        Me.LabelBase5.Location = New System.Drawing.Point(16, 195)
        Me.LabelBase5.Name = "LabelBase5"
        Me.LabelBase5.Size = New System.Drawing.Size(50, 14)
        Me.LabelBase5.TabIndex = 37
        Me.LabelBase5.Text = "Vigencia:"
        '
        'lblTipoTarjetaCredito
        '
        Me.lblTipoTarjetaCredito.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTipoTarjetaCredito.Location = New System.Drawing.Point(104, 168)
        Me.lblTipoTarjetaCredito.Name = "lblTipoTarjetaCredito"
        Me.lblTipoTarjetaCredito.Size = New System.Drawing.Size(160, 21)
        Me.lblTipoTarjetaCredito.TabIndex = 36
        Me.lblTipoTarjetaCredito.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelBase4
        '
        Me.LabelBase4.AutoSize = True
        Me.LabelBase4.Location = New System.Drawing.Point(16, 171)
        Me.LabelBase4.Name = "LabelBase4"
        Me.LabelBase4.Size = New System.Drawing.Size(82, 14)
        Me.LabelBase4.TabIndex = 35
        Me.LabelBase4.Text = "Tipo de tarjeta:"
        '
        'lblBancoNombre
        '
        Me.lblBancoNombre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBancoNombre.Location = New System.Drawing.Point(104, 144)
        Me.lblBancoNombre.Name = "lblBancoNombre"
        Me.lblBancoNombre.Size = New System.Drawing.Size(160, 21)
        Me.lblBancoNombre.TabIndex = 34
        Me.lblBancoNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelBase3
        '
        Me.LabelBase3.AutoSize = True
        Me.LabelBase3.Location = New System.Drawing.Point(16, 147)
        Me.LabelBase3.Name = "LabelBase3"
        Me.LabelBase3.Size = New System.Drawing.Size(38, 14)
        Me.LabelBase3.TabIndex = 33
        Me.LabelBase3.Text = "Banco:"
        '
        'lblTarjetaCredito
        '
        Me.lblTarjetaCredito.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTarjetaCredito.Location = New System.Drawing.Point(104, 120)
        Me.lblTarjetaCredito.Name = "lblTarjetaCredito"
        Me.lblTarjetaCredito.Size = New System.Drawing.Size(160, 21)
        Me.lblTarjetaCredito.TabIndex = 32
        Me.lblTarjetaCredito.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTxtTarjeta
        '
        Me.lblTxtTarjeta.AutoSize = True
        Me.lblTxtTarjeta.Location = New System.Drawing.Point(16, 123)
        Me.lblTxtTarjeta.Name = "lblTxtTarjeta"
        Me.lblTxtTarjeta.Size = New System.Drawing.Size(64, 14)
        Me.lblTxtTarjeta.TabIndex = 26
        Me.lblTxtTarjeta.Text = "No. Tarjeta:"
        '
        'LabelBase1
        '
        Me.LabelBase1.AutoSize = True
        Me.LabelBase1.Location = New System.Drawing.Point(16, 99)
        Me.LabelBase1.Name = "LabelBase1"
        Me.LabelBase1.Size = New System.Drawing.Size(40, 14)
        Me.LabelBase1.TabIndex = 24
        Me.LabelBase1.Text = "Titular:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(16, 35)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(42, 14)
        Me.Label20.TabIndex = 22
        Me.Label20.Text = "Cliente:"
        '
        'lblTitular
        '
        Me.lblTitular.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTitular.Location = New System.Drawing.Point(104, 96)
        Me.lblTitular.Name = "lblTitular"
        Me.lblTitular.Size = New System.Drawing.Size(160, 21)
        Me.lblTitular.TabIndex = 31
        Me.lblTitular.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnBuscarClienteTC
        '
        Me.btnBuscarClienteTC.Image = CType(resources.GetObject("btnBuscarClienteTC.Image"), System.Drawing.Bitmap)
        Me.btnBuscarClienteTC.Location = New System.Drawing.Point(216, 32)
        Me.btnBuscarClienteTC.Name = "btnBuscarClienteTC"
        Me.btnBuscarClienteTC.Size = New System.Drawing.Size(48, 21)
        Me.btnBuscarClienteTC.TabIndex = 1
        '
        'txtNumeroTarjeta
        '
        Me.txtNumeroTarjeta.Location = New System.Drawing.Point(104, 120)
        Me.txtNumeroTarjeta.Name = "txtNumeroTarjeta"
        Me.txtNumeroTarjeta.Size = New System.Drawing.Size(160, 21)
        Me.txtNumeroTarjeta.TabIndex = 2
        Me.txtNumeroTarjeta.Text = ""
        Me.txtNumeroTarjeta.Visible = False
        '
        'comboBancoTDC
        '
        Me.comboBancoTDC.Location = New System.Drawing.Point(104, 144)
        Me.comboBancoTDC.Name = "comboBancoTDC"
        Me.comboBancoTDC.Size = New System.Drawing.Size(160, 21)
        Me.comboBancoTDC.TabIndex = 3
        Me.comboBancoTDC.Text = "ComboBanco1"
        Me.comboBancoTDC.Visible = False
        '
        'tbChequeFicha
        '
        Me.tbChequeFicha.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbTransferencia, Me.chkCargarNI, Me.LabelBase8, Me.txtCodigo, Me.rbNotaIngreso, Me.btnAceptarChequeFicha, Me.grpChequeFicha, Me.rbNotaCredito, Me.rbFicha, Me.rbCheque, Me.btnLeerCodigo})
        Me.tbChequeFicha.Location = New System.Drawing.Point(4, 4)
        Me.tbChequeFicha.Name = "tbChequeFicha"
        Me.tbChequeFicha.Size = New System.Drawing.Size(466, 370)
        Me.tbChequeFicha.TabIndex = 2
        Me.tbChequeFicha.Text = "Cheque / Ficha de deposito"
        '
        'rbTransferencia
        '
        Me.rbTransferencia.Enabled = False
        Me.rbTransferencia.Location = New System.Drawing.Point(280, 16)
        Me.rbTransferencia.Name = "rbTransferencia"
        Me.rbTransferencia.Size = New System.Drawing.Size(136, 16)
        Me.rbTransferencia.TabIndex = 39
        Me.rbTransferencia.Text = "&Transferencia bancaria"
        '
        'chkCargarNI
        '
        Me.chkCargarNI.Checked = True
        Me.chkCargarNI.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCargarNI.Location = New System.Drawing.Point(280, 40)
        Me.chkCargarNI.Name = "chkCargarNI"
        Me.chkCargarNI.Size = New System.Drawing.Size(180, 16)
        Me.chkCargarNI.TabIndex = 38
        Me.chkCargarNI.Text = "Usar nota de ingreso capturada"
        Me.chkCargarNI.Visible = False
        '
        'LabelBase8
        '
        Me.LabelBase8.AutoSize = True
        Me.LabelBase8.Location = New System.Drawing.Point(24, 64)
        Me.LabelBase8.Name = "LabelBase8"
        Me.LabelBase8.Size = New System.Drawing.Size(62, 14)
        Me.LabelBase8.TabIndex = 37
        Me.LabelBase8.Text = "Usar lector:"
        '
        'txtCodigo
        '
        Me.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCodigo.Font = New System.Drawing.Font("Tahoma", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtCodigo.Location = New System.Drawing.Point(112, 64)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(240, 18)
        Me.txtCodigo.TabIndex = 0
        Me.txtCodigo.Text = ""
        Me.ttMensaje.SetToolTip(Me.txtCodigo, "Posicione el cursor en este lugar y deslice el cheque por el lector de c�digo")
        '
        'rbNotaIngreso
        '
        Me.rbNotaIngreso.Location = New System.Drawing.Point(168, 40)
        Me.rbNotaIngreso.Name = "rbNotaIngreso"
        Me.rbNotaIngreso.Size = New System.Drawing.Size(104, 16)
        Me.rbNotaIngreso.TabIndex = 36
        Me.rbNotaIngreso.Text = "&Nota de ingreso"
        '
        'btnAceptarChequeFicha
        '
        Me.btnAceptarChequeFicha.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnAceptarChequeFicha.Image = CType(resources.GetObject("btnAceptarChequeFicha.Image"), System.Drawing.Bitmap)
        Me.btnAceptarChequeFicha.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptarChequeFicha.Location = New System.Drawing.Point(368, 150)
        Me.btnAceptarChequeFicha.Name = "btnAceptarChequeFicha"
        Me.btnAceptarChequeFicha.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptarChequeFicha.TabIndex = 2
        Me.btnAceptarChequeFicha.Text = "&Aceptar"
        Me.btnAceptarChequeFicha.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpChequeFicha
        '
        Me.grpChequeFicha.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnBusquedaCliente, Me.cboNumeroCuenta, Me.txtDocumento, Me.lblNombre, Me.btnBuscarCliente, Me.txtImporteDocumento, Me.txtClienteCheque, Me.txtNumeroCuenta, Me.txtObservaciones, Me.ComboBanco, Me.lblBancoDestino, Me.lblObservaciones, Me.dtpFechaCheque, Me.lblNoCheque, Me.lblFechaCheque, Me.lblNoCuenta, Me.lblImporte, Me.lblCliente, Me.lblBancoOrigen, Me.ComboBancoOrigen, Me.txtNumeroCuentaOrigen, Me.lblCtaDestino})
        Me.grpChequeFicha.Location = New System.Drawing.Point(24, 80)
        Me.grpChequeFicha.Name = "grpChequeFicha"
        Me.grpChequeFicha.Size = New System.Drawing.Size(328, 285)
        Me.grpChequeFicha.TabIndex = 0
        Me.grpChequeFicha.TabStop = False
        '
        'cboNumeroCuenta
        '
        Me.cboNumeroCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNumeroCuenta.Location = New System.Drawing.Point(120, 72)
        Me.cboNumeroCuenta.Name = "cboNumeroCuenta"
        Me.cboNumeroCuenta.Size = New System.Drawing.Size(192, 21)
        Me.cboNumeroCuenta.TabIndex = 2
        Me.cboNumeroCuenta.Visible = False
        '
        'txtDocumento
        '
        Me.txtDocumento.Location = New System.Drawing.Point(120, 24)
        Me.txtDocumento.MaxLength = 10
        Me.txtDocumento.Name = "txtDocumento"
        Me.txtDocumento.Size = New System.Drawing.Size(192, 21)
        Me.txtDocumento.TabIndex = 0
        Me.txtDocumento.Text = ""
        '
        'lblNombre
        '
        Me.lblNombre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNombre.Location = New System.Drawing.Point(120, 120)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(192, 21)
        Me.lblNombre.TabIndex = 5
        Me.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.Image = CType(resources.GetObject("btnBuscarCliente.Image"), System.Drawing.Bitmap)
        Me.btnBuscarCliente.Location = New System.Drawing.Point(272, 96)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(40, 21)
        Me.btnBuscarCliente.TabIndex = 31
        Me.btnBuscarCliente.Tag = "Consulta de datos del cliente"
        '
        'txtImporteDocumento
        '
        Me.txtImporteDocumento.Location = New System.Drawing.Point(120, 168)
        Me.txtImporteDocumento.Name = "txtImporteDocumento"
        Me.txtImporteDocumento.Size = New System.Drawing.Size(192, 21)
        Me.txtImporteDocumento.TabIndex = 7
        Me.txtImporteDocumento.Text = ""
        '
        'txtClienteCheque
        '
        Me.txtClienteCheque.Location = New System.Drawing.Point(120, 96)
        Me.txtClienteCheque.Name = "txtClienteCheque"
        Me.txtClienteCheque.Size = New System.Drawing.Size(104, 21)
        Me.txtClienteCheque.TabIndex = 4
        Me.txtClienteCheque.Text = ""
        '
        'txtNumeroCuenta
        '
        Me.txtNumeroCuenta.Location = New System.Drawing.Point(120, 72)
        Me.txtNumeroCuenta.Name = "txtNumeroCuenta"
        Me.txtNumeroCuenta.Size = New System.Drawing.Size(192, 21)
        Me.txtNumeroCuenta.TabIndex = 2
        Me.txtNumeroCuenta.Text = ""
        '
        'txtObservaciones
        '
        Me.txtObservaciones.AutoSize = False
        Me.txtObservaciones.Location = New System.Drawing.Point(120, 240)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(192, 32)
        Me.txtObservaciones.TabIndex = 8
        Me.txtObservaciones.Text = ""
        '
        'ComboBanco
        '
        Me.ComboBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBanco.DropDownWidth = 200
        Me.ComboBanco.Location = New System.Drawing.Point(120, 144)
        Me.ComboBanco.Name = "ComboBanco"
        Me.ComboBanco.Size = New System.Drawing.Size(192, 21)
        Me.ComboBanco.TabIndex = 6
        '
        'lblBancoDestino
        '
        Me.lblBancoDestino.AutoSize = True
        Me.lblBancoDestino.Location = New System.Drawing.Point(8, 147)
        Me.lblBancoDestino.Name = "lblBancoDestino"
        Me.lblBancoDestino.Size = New System.Drawing.Size(38, 14)
        Me.lblBancoDestino.TabIndex = 15
        Me.lblBancoDestino.Text = "Banco:"
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.Location = New System.Drawing.Point(8, 240)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(80, 14)
        Me.lblObservaciones.TabIndex = 21
        Me.lblObservaciones.Text = "Observaciones:"
        '
        'dtpFechaCheque
        '
        Me.dtpFechaCheque.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFechaCheque.Location = New System.Drawing.Point(120, 48)
        Me.dtpFechaCheque.Name = "dtpFechaCheque"
        Me.dtpFechaCheque.Size = New System.Drawing.Size(192, 21)
        Me.dtpFechaCheque.TabIndex = 1
        '
        'lblNoCheque
        '
        Me.lblNoCheque.AutoSize = True
        Me.lblNoCheque.Location = New System.Drawing.Point(8, 27)
        Me.lblNoCheque.Name = "lblNoCheque"
        Me.lblNoCheque.Size = New System.Drawing.Size(86, 14)
        Me.lblNoCheque.TabIndex = 3
        Me.lblNoCheque.Text = "No. Documento:"
        '
        'lblFechaCheque
        '
        Me.lblFechaCheque.AutoSize = True
        Me.lblFechaCheque.Location = New System.Drawing.Point(8, 51)
        Me.lblFechaCheque.Name = "lblFechaCheque"
        Me.lblFechaCheque.Size = New System.Drawing.Size(97, 14)
        Me.lblFechaCheque.TabIndex = 16
        Me.lblFechaCheque.Text = "Fecha documento:"
        '
        'lblNoCuenta
        '
        Me.lblNoCuenta.AutoSize = True
        Me.lblNoCuenta.Location = New System.Drawing.Point(8, 75)
        Me.lblNoCuenta.Name = "lblNoCuenta"
        Me.lblNoCuenta.Size = New System.Drawing.Size(64, 14)
        Me.lblNoCuenta.TabIndex = 12
        Me.lblNoCuenta.Text = "No. Cuenta:"
        '
        'lblImporte
        '
        Me.lblImporte.AutoSize = True
        Me.lblImporte.Location = New System.Drawing.Point(8, 171)
        Me.lblImporte.Name = "lblImporte"
        Me.lblImporte.Size = New System.Drawing.Size(48, 14)
        Me.lblImporte.TabIndex = 19
        Me.lblImporte.Text = "Importe:"
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Location = New System.Drawing.Point(8, 104)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(42, 14)
        Me.lblCliente.TabIndex = 13
        Me.lblCliente.Text = "Cliente:"
        '
        'lblBancoOrigen
        '
        Me.lblBancoOrigen.AutoSize = True
        Me.lblBancoOrigen.Location = New System.Drawing.Point(8, 195)
        Me.lblBancoOrigen.Name = "lblBancoOrigen"
        Me.lblBancoOrigen.Size = New System.Drawing.Size(73, 14)
        Me.lblBancoOrigen.TabIndex = 35
        Me.lblBancoOrigen.Text = "Banco origen:"
        '
        'ComboBancoOrigen
        '
        Me.ComboBancoOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBancoOrigen.DropDownWidth = 200
        Me.ComboBancoOrigen.Enabled = False
        Me.ComboBancoOrigen.Location = New System.Drawing.Point(120, 192)
        Me.ComboBancoOrigen.Name = "ComboBancoOrigen"
        Me.ComboBancoOrigen.Size = New System.Drawing.Size(192, 21)
        Me.ComboBancoOrigen.TabIndex = 34
        '
        'txtNumeroCuentaOrigen
        '
        Me.txtNumeroCuentaOrigen.Enabled = False
        Me.txtNumeroCuentaOrigen.Location = New System.Drawing.Point(120, 216)
        Me.txtNumeroCuentaOrigen.Name = "txtNumeroCuentaOrigen"
        Me.txtNumeroCuentaOrigen.Size = New System.Drawing.Size(192, 21)
        Me.txtNumeroCuentaOrigen.TabIndex = 3
        Me.txtNumeroCuentaOrigen.Text = ""
        '
        'lblCtaDestino
        '
        Me.lblCtaDestino.AutoSize = True
        Me.lblCtaDestino.Location = New System.Drawing.Point(8, 219)
        Me.lblCtaDestino.Name = "lblCtaDestino"
        Me.lblCtaDestino.Size = New System.Drawing.Size(101, 14)
        Me.lblCtaDestino.TabIndex = 33
        Me.lblCtaDestino.Text = "No. Cuenta Origen:"
        '
        'rbNotaCredito
        '
        Me.rbNotaCredito.Location = New System.Drawing.Point(168, 16)
        Me.rbNotaCredito.Name = "rbNotaCredito"
        Me.rbNotaCredito.Size = New System.Drawing.Size(104, 16)
        Me.rbNotaCredito.TabIndex = 35
        Me.rbNotaCredito.Text = "&Nota de cr�dito"
        '
        'rbFicha
        '
        Me.rbFicha.Location = New System.Drawing.Point(32, 40)
        Me.rbFicha.Name = "rbFicha"
        Me.rbFicha.Size = New System.Drawing.Size(120, 16)
        Me.rbFicha.TabIndex = 30
        Me.rbFicha.Text = "&Ficha de dep�sito"
        '
        'rbCheque
        '
        Me.rbCheque.Checked = True
        Me.rbCheque.Location = New System.Drawing.Point(32, 16)
        Me.rbCheque.Name = "rbCheque"
        Me.rbCheque.Size = New System.Drawing.Size(64, 16)
        Me.rbCheque.TabIndex = 29
        Me.rbCheque.TabStop = True
        Me.rbCheque.Text = "&Cheque"
        '
        'btnLeerCodigo
        '
        Me.btnLeerCodigo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLeerCodigo.Image = CType(resources.GetObject("btnLeerCodigo.Image"), System.Drawing.Bitmap)
        Me.btnLeerCodigo.Location = New System.Drawing.Point(320, 64)
        Me.btnLeerCodigo.Name = "btnLeerCodigo"
        Me.btnLeerCodigo.Size = New System.Drawing.Size(32, 18)
        Me.btnLeerCodigo.TabIndex = 1
        Me.btnLeerCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ttMensaje.SetToolTip(Me.btnLeerCodigo, "Codifica el resultado de la lectura")
        '
        'tbSaldoAFavor
        '
        Me.tbSaldoAFavor.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnAceptarSF, Me.GroupBox1, Me.grpOrigen})
        Me.tbSaldoAFavor.Location = New System.Drawing.Point(4, 4)
        Me.tbSaldoAFavor.Name = "tbSaldoAFavor"
        Me.tbSaldoAFavor.Size = New System.Drawing.Size(466, 370)
        Me.tbSaldoAFavor.TabIndex = 4
        Me.tbSaldoAFavor.Text = "Saldo a favor"
        '
        'btnAceptarSF
        '
        Me.btnAceptarSF.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnAceptarSF.Image = CType(resources.GetObject("btnAceptarSF.Image"), System.Drawing.Bitmap)
        Me.btnAceptarSF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptarSF.Location = New System.Drawing.Point(378, 161)
        Me.btnAceptarSF.Name = "btnAceptarSF"
        Me.btnAceptarSF.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptarSF.TabIndex = 4
        Me.btnAceptarSF.Text = "&Aceptar"
        Me.btnAceptarSF.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblSFA�oCobro, Me.Label15, Me.lblSFImporte, Me.Label13, Me.Label12, Me.Label11, Me.Label10, Me.lblSFCobro, Me.lblSFTipo, Me.lblSFMovimientoOrigen, Me.lblSaldoAFavorNombre, Me.lblSFCliente, Me.Label9})
        Me.GroupBox1.Location = New System.Drawing.Point(15, 141)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(358, 210)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'lblSFA�oCobro
        '
        Me.lblSFA�oCobro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSFA�oCobro.Location = New System.Drawing.Point(144, 116)
        Me.lblSFA�oCobro.Name = "lblSFA�oCobro"
        Me.lblSFA�oCobro.Size = New System.Drawing.Size(48, 23)
        Me.lblSFA�oCobro.TabIndex = 16
        Me.lblSFA�oCobro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(12, 176)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(48, 14)
        Me.Label15.TabIndex = 15
        Me.Label15.Text = "Importe:"
        '
        'lblSFImporte
        '
        Me.lblSFImporte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSFImporte.Location = New System.Drawing.Point(144, 172)
        Me.lblSFImporte.Name = "lblSFImporte"
        Me.lblSFImporte.Size = New System.Drawing.Size(200, 23)
        Me.lblSFImporte.TabIndex = 14
        Me.lblSFImporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 147)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(30, 14)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Tipo:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 120)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(38, 14)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "Cobro:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 94)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(101, 14)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Movimiento origen:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 48)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 14)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Nombre:"
        '
        'lblSFCobro
        '
        Me.lblSFCobro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSFCobro.Location = New System.Drawing.Point(195, 116)
        Me.lblSFCobro.Name = "lblSFCobro"
        Me.lblSFCobro.Size = New System.Drawing.Size(149, 23)
        Me.lblSFCobro.TabIndex = 4
        Me.lblSFCobro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSFTipo
        '
        Me.lblSFTipo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSFTipo.Location = New System.Drawing.Point(144, 143)
        Me.lblSFTipo.Name = "lblSFTipo"
        Me.lblSFTipo.Size = New System.Drawing.Size(200, 23)
        Me.lblSFTipo.TabIndex = 3
        Me.lblSFTipo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSFMovimientoOrigen
        '
        Me.lblSFMovimientoOrigen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSFMovimientoOrigen.Location = New System.Drawing.Point(144, 90)
        Me.lblSFMovimientoOrigen.Name = "lblSFMovimientoOrigen"
        Me.lblSFMovimientoOrigen.Size = New System.Drawing.Size(200, 23)
        Me.lblSFMovimientoOrigen.TabIndex = 2
        Me.lblSFMovimientoOrigen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSaldoAFavorNombre
        '
        Me.lblSaldoAFavorNombre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSaldoAFavorNombre.Location = New System.Drawing.Point(144, 48)
        Me.lblSaldoAFavorNombre.Name = "lblSaldoAFavorNombre"
        Me.lblSaldoAFavorNombre.Size = New System.Drawing.Size(200, 38)
        Me.lblSaldoAFavorNombre.TabIndex = 1
        '
        'lblSFCliente
        '
        Me.lblSFCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSFCliente.Location = New System.Drawing.Point(144, 21)
        Me.lblSFCliente.Name = "lblSFCliente"
        Me.lblSFCliente.Size = New System.Drawing.Size(200, 23)
        Me.lblSFCliente.TabIndex = 0
        Me.lblSFCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 14)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Cliente:"
        '
        'grpOrigen
        '
        Me.grpOrigen.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtSFA�oAtt, Me.btnSFBuscar, Me.txtSFFolioAtt, Me.Label4, Me.Label3, Me.txtSFCliente, Me.Label2, Me.Label1, Me.txtSFClave})
        Me.grpOrigen.Location = New System.Drawing.Point(14, 16)
        Me.grpOrigen.Name = "grpOrigen"
        Me.grpOrigen.Size = New System.Drawing.Size(359, 120)
        Me.grpOrigen.TabIndex = 0
        Me.grpOrigen.TabStop = False
        Me.grpOrigen.Text = "Movimiento origen"
        '
        'txtSFA�oAtt
        '
        Me.txtSFA�oAtt.Location = New System.Drawing.Point(144, 67)
        Me.txtSFA�oAtt.Name = "txtSFA�oAtt"
        Me.txtSFA�oAtt.Size = New System.Drawing.Size(147, 21)
        Me.txtSFA�oAtt.TabIndex = 9
        Me.txtSFA�oAtt.Text = ""
        '
        'btnSFBuscar
        '
        Me.btnSFBuscar.Image = CType(resources.GetObject("btnSFBuscar.Image"), System.Drawing.Bitmap)
        Me.btnSFBuscar.Location = New System.Drawing.Point(301, 20)
        Me.btnSFBuscar.Name = "btnSFBuscar"
        Me.btnSFBuscar.Size = New System.Drawing.Size(48, 21)
        Me.btnSFBuscar.TabIndex = 8
        '
        'txtSFFolioAtt
        '
        Me.txtSFFolioAtt.Location = New System.Drawing.Point(144, 90)
        Me.txtSFFolioAtt.Name = "txtSFFolioAtt"
        Me.txtSFFolioAtt.Size = New System.Drawing.Size(147, 21)
        Me.txtSFFolioAtt.TabIndex = 7
        Me.txtSFFolioAtt.Text = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 14)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Folio:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 14)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "A�oatt:"
        '
        'txtSFCliente
        '
        Me.txtSFCliente.Location = New System.Drawing.Point(144, 44)
        Me.txtSFCliente.Name = "txtSFCliente"
        Me.txtSFCliente.Size = New System.Drawing.Size(147, 21)
        Me.txtSFCliente.TabIndex = 3
        Me.txtSFCliente.Text = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Cliente:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 14)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Clave del movimiento:"
        '
        'txtSFClave
        '
        Me.txtSFClave.Location = New System.Drawing.Point(144, 21)
        Me.txtSFClave.Name = "txtSFClave"
        Me.txtSFClave.Size = New System.Drawing.Size(147, 21)
        Me.txtSFClave.TabIndex = 0
        Me.txtSFClave.Text = ""
        '
        'imgLista
        '
        Me.imgLista.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgLista.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgLista.TransparentColor = System.Drawing.Color.Transparent
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(128, 56)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "&Cancelar"
        '
        'ComboBanco1
        '
        Me.ComboBanco1.Location = New System.Drawing.Point(104, 144)
        Me.ComboBanco1.Name = "ComboBanco1"
        Me.ComboBanco1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBanco1.TabIndex = 0
        '
        'btnBusquedaCliente
        '
        Me.btnBusquedaCliente.Image = CType(resources.GetObject("btnBusquedaCliente.Image"), System.Drawing.Bitmap)
        Me.btnBusquedaCliente.Location = New System.Drawing.Point(228, 96)
        Me.btnBusquedaCliente.Name = "btnBusquedaCliente"
        Me.btnBusquedaCliente.Size = New System.Drawing.Size(40, 21)
        Me.btnBusquedaCliente.TabIndex = 36
        Me.btnBusquedaCliente.Tag = "B�squeda de clientes"
        '
        'frmSelTipoCobro
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(474, 396)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tabTipoCobro, Me.btnCancelar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSelTipoCobro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Captura de cobros"
        Me.tabTipoCobro.ResumeLayout(False)
        Me.tbEfectivoVales.ResumeLayout(False)
        Me.grpEfectivoVales.ResumeLayout(False)
        Me.tbTarjetaCredito.ResumeLayout(False)
        Me.grpTarjetaCredito.ResumeLayout(False)
        Me.tbChequeFicha.ResumeLayout(False)
        Me.grpChequeFicha.ResumeLayout(False)
        Me.tbSaldoAFavor.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.grpOrigen.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Cobros"

    'EFECTIVO Y / O VALES
    Private Sub btnAceptarEfectivoVales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptarEfectivoVales.Click
        'Validar que el tipo de cobro seleccionado se puede capturar en este tipo de movimiento JAG 23-01-2008
        If GLOBAL_ValidarTipoCobro Then
            If Not ValidarTipoCobro(_TipoMovimientoCaja, SigaMetClasses.Enumeradores.enumTipoCobro.EfectivoVales) Then
                Exit Sub
            End If
        End If

        If CapturaEfectivoVales = False Then
            If txtTotalEfectivoVales.Text <> "" And IsNumeric(txtTotalEfectivoVales.Text) Then
                If _CapturaDetalle = True Then
                    Dim frmCaptura As frmCapCobranzaDoc
                    If Not _EsRelacionCobranza Then
                        frmCaptura = New frmCapCobranzaDoc(_TipoMovimientoCaja, _SoloDocumentosCartera, _ListaCobros)
                    Else
                        frmCaptura = New frmCapCobranzaDoc(_TipoMovimientoCaja, _SoloDocumentosCartera, _ListaCobros, _RelacionCobranza)
                    End If

                    frmCaptura.TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.EfectivoVales
                    frmCaptura.ImporteCobro = CType(txtTotalEfectivoVales.Text, Decimal)

                    If frmCaptura.ShowDialog = DialogResult.OK Then
                        With Cobro
                            .Consecutivo = _Consecutivo
                            .AnoCobro = CType(FechaOperacion.Year, Short)
                            .TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.EfectivoVales
                            .Total = frmCaptura.ImporteCobro
                            .ListaPedidos = frmCaptura.ListaCobroPedido
                            ImporteTotalCobro = .Total
                        End With
                        DialogResult = DialogResult.OK
                    End If

                Else
                    With Cobro
                        .Consecutivo = _Consecutivo
                        .AnoCobro = CType(FechaOperacion.Year, Short)
                        .TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.EfectivoVales
                        .Total = CType(txtTotalEfectivoVales.Text, Decimal)
                        ImporteTotalCobro = .Total
                        .ListaPedidos = Nothing
                    End With
                    DialogResult = DialogResult.OK
                End If

            End If
        Else
            MessageBox.Show("Ya captur� efectivo o vales")
        End If
    End Sub

    'TARJETA DE CREDITO
    Private Sub btnAceptarTarjetaCredito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptarTarjetaCredito.Click
        'Validar que el tipo de cobro seleccionado se puede capturar en este tipo de movimiento JAG 23-01-2008
        If GLOBAL_ValidarTipoCobro Then
            If Not ValidarTipoCobro(_TipoMovimientoCaja, SigaMetClasses.Enumeradores.enumTipoCobro.TarjetaCredito) Then
                Exit Sub
            End If
        End If

        If lblClienteNombre.Text <> "" Then
            If txtImporteTC.Text <> "" And IsNumeric(txtImporteTC.Text) Then
                If _CapturaDetalle = True Then
                    Dim frmCaptura As New frmCapCobranzaDoc(_TipoMovimientoCaja, _SoloDocumentosCartera, _ListaCobros)
                    frmCaptura.TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.TarjetaCredito
                    frmCaptura.ImporteCobro = CType(txtImporteTC.Text, Decimal)

                    If frmCaptura.ShowDialog = DialogResult.OK Then
                        With Cobro
                            .Consecutivo = _Consecutivo
                            .AnoCobro = CType(FechaOperacion.Year, Short)
                            .TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.TarjetaCredito
                            .Total = frmCaptura.ImporteCobro
                            .Cliente = CType(txtClienteTC.Text, Integer)
                            .Banco = CType(lblBanco.Text, Short)
                            .NoCuenta = lblTarjetaCredito.Text
                            .ListaPedidos = frmCaptura.ListaCobroPedido
                            ImporteTotalCobro = .Total
                        End With
                        DialogResult = DialogResult.OK
                    End If
                Else
                    With Cobro
                        .Consecutivo = _Consecutivo
                        .AnoCobro = CType(FechaOperacion.Year, Short)
                        .TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.TarjetaCredito
                        .Total = CType(txtImporteTC.Text, Decimal)
                        .Cliente = CType(txtClienteTC.Text, Integer)
                        .Banco = CType(lblBanco.Text, Short)
                        .NoCuenta = lblTarjetaCredito.Text
                        .ListaPedidos = Nothing
                        ImporteTotalCobro = .Total
                    End With
                    DialogResult = DialogResult.OK
                End If
            Else
                MessageBox.Show("Debe teclear el importe del cobro.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("Debe teclear el n�mero de cliente.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        If chkCapturaTPV.Checked Then
            If txtNumeroTarjeta.Text.Trim.Length = 0 Then
                MessageBox.Show("Debe teclear el n�mero de autorizaci�n.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub



    'CHEQUE Y FICHA DE DEPOSITO
    Private Sub btnAceptarChequeFicha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptarChequeFicha.Click
        'Validar que el tipo de cobro seleccionado se puede capturar en este tipo de movimiento JAG 23-01-2008
        If GLOBAL_ValidarTipoCobro Then
            If Not ValidarTipoCobro(_TipoMovimientoCaja, _TipoCobro) Then
                Exit Sub
            End If
        End If

        'Control de clientes en pagos con cheque
        Dim _cuentaErronea As Boolean

        'Control de cheques posfechados
        Dim _posfechado As Boolean
        '*****

        'Aplicaci�n de notas de cr�dito v�lidas
        If _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.NotaCredito And GLOBAL_AplicaValidaci�nNotaCredito Then
            'If Not validaNotaCredito(CType(txtDocumento.Text.Trim, Integer)) Then
            '    MessageBox.Show("Esta nota de cr�dito ya fue aplicada, est� cancelada, no es una nota de" & Chr(13) & _
            '                                        "cr�dito v�lida o no es una nota de cr�dito manual, por favor verifique", "Nota no v�lida", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Exit Sub
            'End If
        End If

        If txtDocumento.Text.Trim.Length <> 7 And rbCheque.Checked = True Then
            MessageBox.Show("El n�mero de documento debe ser de 7 d�gitos.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDocumento.Focus()
            txtDocumento.SelectAll()
            Exit Sub
        End If

        If rbCheque.Checked = True AndAlso _
            Not (txtNumeroCuenta.Text.Trim.Length >= CType(Main.GLOBAL_MinLenCuenta, Integer) AndAlso _
                txtNumeroCuenta.Text.Trim.Length <= CType(Main.GLOBAL_MaxLenCuenta, Integer)) Then
            MessageBox.Show(mensajeNumeroCuenta(Main.GLOBAL_MinLenCuenta, Main.GLOBAL_MaxLenCuenta) & vbCrLf & _
                "verifique.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDocumento.Focus()
            txtDocumento.SelectAll()
            Exit Sub
        End If

        'Validar aqu� el consecutivo del n�mero de cheque, parametrizar
        If rbCheque.Checked = True AndAlso GLOBAL_ValidarConsCheque Then
            Try
                If Not numeroCuentaClienteValido(SigaMetClasses.DataLayer.Conexion, CType(txtClienteCheque.Text, Integer), _
                    CType(ComboBanco.SelectedValue, Short), Trim(txtNumeroCuenta.Text)) Then
                    Dim _mensajeChequeErroneo As String = "El cliente " & txtClienteCheque.Text.Trim & _
                        " no paga regularmente con el n�mero de cuenta que captur�."
                    'Usuario no autorizado para esta captura, no se permite realizarla
                    If Not oSeguridad.TieneAcceso("CAPT_CHQ_CONSECUTIVOERR") Then
                        MessageBox.Show(_mensajeChequeErroneo & vbCrLf & _
                        "No podr� continuar con el registro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    Else
                        'Autorizaci�n para captura del documento con consecutivo err�neo
                        If MessageBox.Show(_mensajeChequeErroneo & vbCrLf & _
                            "�Desea continuar con su registro?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                            <> DialogResult.Yes Then
                            Exit Sub
                        Else
                            _cuentaErronea = True
                        End If
                    End If
                    '*****
                End If
            Catch ex As Exception
                EventLog.WriteEntry("Application", ex.ToString)
            End Try
        End If
        '*****

        'Control de cheques posfechados
        If rbCheque.Checked = True And GLOBAL_Posfechado Then
            'Comparar contra el periodo m�ximo
            If DateDiff(DateInterval.Day, DateTime.Today.Date, dtpFechaCheque.Value.Date) > GLOBAL_LimitePosfechado Then
                If MessageBox.Show("Este documento se registrar� como posfechado" & vbCrLf & _
                                        "�Desea continuar con su registro?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                                        <> DialogResult.Yes Then
                    Exit Sub
                Else
                    _posfechado = True
                End If
            End If
        End If
        '*****

        If _CargaNotaIngreso = False Then
            If Not ValidaCapturaChequeFicha() Then
                Exit Sub
            End If
        End If

        'Validaci�n de notas de ingreso
        If rbNotaIngreso.Checked AndAlso GLOBAL_ValidarNI Then
            If Not validarNotadeIngreso(txtDocumento.Text) Then
                Exit Sub
            End If
        End If

        If _CapturaDetalle = True Then
            If txtClienteCheque.Text.Trim = "" Then
                MessageBox.Show("El documento no tiene cliente  asignado.", Me.Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If BuscaCobroGlobal(UCase(Trim(txtDocumento.Text)), _
                                            CType(Trim(txtClienteCheque.Text), Integer), _
                                            CType(ComboBanco.SelectedValue, Short)) = False Then

                Dim frmCaptura As frmCapCobranzaDoc
                If Not _EsRelacionCobranza Then
                    frmCaptura = New frmCapCobranzaDoc(_TipoMovimientoCaja, _SoloDocumentosCartera, _ListaCobros)
                Else
                    frmCaptura = New frmCapCobranzaDoc(_TipoMovimientoCaja, _SoloDocumentosCartera, _ListaCobros, _RelacionCobranza)
                End If
                frmCaptura.TipoCobro = _TipoCobro
                frmCaptura.ImporteCobro = CType(txtImporteDocumento.Text, Decimal)

                'Para control de saldos a favor (Le pasamos el cliente del cheque para validar que se pueda capturar) 04/04/2005
                frmCaptura.Cliente = CType(Val(txtClienteCheque.Text), Integer)

                'Validar el contrato en la aplicaci�n de pagos con cheque
                If GLOBAL_ValidarClienteCheque Then
                    Dim ClientesRelacionados As New CyCSaldoAFavor.saldoAFavor()
                    frmCaptura.ClientesRelacionados(CType(Val(txtClienteCheque.Text), Integer)) = _
                        ClientesRelacionados.ClientesRelacionados(CType(Val(txtClienteCheque.Text), Integer), GLOBAL_connection)
                End If
                '****

                If frmCaptura.ShowDialog() = DialogResult.OK Then
                    With Cobro
                        .Consecutivo = _Consecutivo
                        .AnoCobro = CType(FechaOperacion.Year, Short)
                        .TipoCobro = _TipoCobro
                        .Total = frmCaptura.ImporteCobro
                        .Saldo = frmCaptura.ImporteRestante
                        .NoCheque = Trim(txtDocumento.Text)
                        .FechaCheque = dtpFechaCheque.Value.Date
                        .NoCuenta = Trim(txtNumeroCuenta.Text)
                        .Cliente = CType(txtClienteCheque.Text, Integer)
                        .Banco = CType(ComboBanco.SelectedValue, Short)
                        .Observaciones = Trim(txtObservaciones.Text)
                        .ListaPedidos = frmCaptura.ListaCobroPedido
                        ImporteTotalCobro = .Total

                        'Se agreg� para captura de transferencias bancarias
                        '23-03-2005 JAG
                        .NoCuentaDestino = txtNumeroCuentaOrigen.Text
                        .BancoOrigen = CType(ComboBancoOrigen.SelectedValue, Short)

                        .SaldoAFavor = frmCaptura.SaldoAFavor

                        'Control de cheques posfechados
                        If rbCheque.Checked = True Then
                            .Posfechado = _posfechado
                        End If
                    End With

                    'Control de clientes en pagos con cheque
                    If _cuentaErronea Then
                        'Registrar en bit�cora si se realiza el registro
                        Try
                            Main.BitacoraCheque(SigaMetClasses.DataLayer.Conexion, Nothing, Nothing, CType(txtClienteCheque.Text, Integer), _
                                "Registro de cheque con cuenta err�nea: " & CType(CType(ComboBanco.SelectedItem(), DataRowView)(1), String).Trim & _
                                " " & Trim(txtNumeroCuenta.Text) & " " & Trim(txtDocumento.Text), GLOBAL_IDUsuario)
                        Catch ex As Exception
                            EventLog.WriteEntry("Application", ex.ToString)
                        End Try
                    End If
                    '*****

                    'Control de cheques posfechados
                    _ChequePosfechado = Cobro.Posfechado
                    '*****

                    DialogResult = DialogResult.OK
                End If
            Else
                MessageBox.Show("El cobro ya existe en el movimiento.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            With Cobro
                .Consecutivo = _Consecutivo
                .AnoCobro = CType(FechaOperacion.Year, Short)
                .TipoCobro = _TipoCobro
                .Total = CType(txtImporteDocumento.Text, Decimal)
                .Saldo = 0
                .NoCheque = Trim(txtDocumento.Text)
                .FechaCheque = dtpFechaCheque.Value.Date
                .NoCuenta = Trim(txtNumeroCuenta.Text)
                .Cliente = CType(txtClienteCheque.Text, Integer)
                .Banco = CType(ComboBanco.SelectedValue, Short)
                .Observaciones = Trim(txtObservaciones.Text)
                .ListaPedidos = Nothing
                ImporteTotalCobro = .Total
            End With
            DialogResult = DialogResult.OK
        End If
    End Sub

#End Region


    Private Function BuscaCobroGlobal(ByVal Documento As String, _
                                      ByVal Cliente As Integer, _
                                      ByVal Banco As Short) As Boolean
        Dim _sCobro As SigaMetClasses.sCobro
        For Each _sCobro In _ListaCobros.Items
            If _sCobro.NoCheque = Documento And _
                _sCobro.Cliente = Cliente And _
                _sCobro.Banco = Banco Then
                Return True
                Exit Function
            End If
        Next
        Return False

    End Function

    Private Function ValidaCapturaChequeFicha() As Boolean
        If txtImporteDocumento.Text = "" Or Not IsNumeric(txtImporteDocumento.Text) Then
            MessageBox.Show("Debe teclear el importe del documento.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        If Trim(txtDocumento.Text) = "" Or Not IsNumeric(txtDocumento.Text) Then
            MessageBox.Show("Debe teclear el n�mero del documento.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDocumento.Focus()
            txtDocumento.SelectAll()
            Return False
        End If

        If txtDocumento.Text.Trim.Length <> 7 And rbCheque.Checked = True Then
            MessageBox.Show("El n�mero de documento debe ser de 7 d�gitos.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtDocumento.Focus()
            txtDocumento.SelectAll()
            Return False
        End If

        If Trim(txtNumeroCuenta.Text) = "" Or Not IsNumeric(txtNumeroCuenta.Text) Then
            MessageBox.Show("Debe teclear el n�mero de cuenta.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNumeroCuenta.Focus()
            txtNumeroCuenta.SelectAll()
            Return False
        End If

        If txtClienteCheque.Text = "" Or Not IsNumeric(txtClienteCheque.Text) Or lblNombre.Text = "" Then
            MessageBox.Show("Debe teclear el n�mero de un cliente v�lido.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtClienteCheque.Focus()
            txtClienteCheque.SelectAll()
            Return False
        End If

        If _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.Cheque Or _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.FichaDeposito Then
            If CType(ComboBanco.SelectedValue, Short) <= 0 Then
                MessageBox.Show("Debe seleccionar el banco.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
        End If

        'Modificaci�n para captura de transferencias bancarias
        '23-03-2005 Jorge A. Guerrero Dom�nguez
        If _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.Transferencia Then

            If Trim(txtNumeroCuentaOrigen.Text) = "" Or Not IsNumeric(txtNumeroCuentaOrigen.Text) Then
                MessageBox.Show("Debe teclear el n�mero de cuenta origen.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtNumeroCuenta.Focus()
                txtNumeroCuenta.SelectAll()
                Return False
            End If

        End If


        Return True
    End Function

    Private Sub tabTipoCobro_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabTipoCobro.SelectedIndexChanged
        Select Case tabTipoCobro.SelectedTab.Name
            Case Is = "tbEfectivoVales"
                AcceptButton = btnAceptarEfectivoVales
                txtTotalEfectivoVales.Focus()
            Case Is = "tbChequeFicha"
                AcceptButton = btnAceptarChequeFicha
                txtCodigo.Focus()
            Case Is = "tbTarjetaCredito"
                AcceptButton = btnAceptarTarjetaCredito
                txtClienteTC.Focus()
        End Select
    End Sub

    Private Sub frmSelTipoCobro_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBanco.CargaDatos(CargaBancoCero:=True, MostrarClaves:=True, SoloActivos:=True)
        'TDC
        comboBancoTDC.CargaDatos(CargaBancoCero:=False, MostrarClaves:=True, SoloActivos:=True)

        If CapturaEfectivoVales = True Then
            btnAceptarEfectivoVales.Enabled = False
            tabTipoCobro.SelectedTab = tbChequeFicha
        End If
        AddHandler txtImporteTC.KeyDown, AddressOf ManejaFlechas

        'Modificaci�n para captura de transferencias bancarias
        '23-03-2005 Jorge A. Guerrero Dom�nguez
        If GLOBAL_TransferenciaActiva AndAlso _
           _TipoMovimientoCaja = GLOBAL_TipoMovimientoTransferencia Then 'Transferencia bancaria
            rbTransferencia.Enabled = True
            'rbTransferencia.Checked = True
            tabTipoCobro.SelectedTab = tbChequeFicha
        End If

        'Modificacion para captura de abonos por saldo a favor
        If Not GLOBAL_AplicacionSaldoAFavor Then
            Me.tbSaldoAFavor.Enabled = False
        End If

        'Captura de recibos TPV
        Me.chkCapturaTPV.Visible = oSeguridad.TieneAcceso("CAPTURA_TPV")

        'Permitir Solo notas de cr�dito capturadas
        chkCargarNI.Enabled = Not GLOBAL_SoloNICapturada
    End Sub

    Private Sub txtClienteTC_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AcceptButton = btnBuscarClienteTC
    End Sub

    Private Sub txtClienteTC_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AcceptButton = btnAceptarTarjetaCredito
    End Sub

    Private Sub LimpiaInfoTarjetaCredito()
        lblClienteNombre.Text = ""
        lblTitular.Text = ""
        lblTarjetaCredito.Text = ""
        lblBancoNombre.Text = ""
        lblTipoTarjetaCredito.Text = ""
        lblVigencia.Text = ""
    End Sub

    Private Sub ConsultaTarjetaCredito(ByVal Cliente As Integer)
        Dim oTC As New SigaMetClasses.cTarjetaCredito()
        Dim dr As SqlDataReader
        dr = oTC.ConsultaActiva(Cliente)
        Do While dr.Read
            lblClienteNombre.Text = CType(dr("ClienteNombre"), String)
            lblTitular.Text = CType(dr("Titular"), String)
            lblTarjetaCredito.Text = CType(dr("TarjetaCredito"), String)
            lblBanco.Text = CType(dr("Banco"), String)
            lblBancoNombre.Text = CType(dr("BancoNombre"), String)
            lblTipoTarjetaCredito.Text = CType(dr("TipoTarjetaCreditoDescripcion"), String)
            lblVigencia.Text = CType(dr("MesVigencia"), String) & " / " & CType(dr("A�oVigencia"), String)
        Loop
        dr.Close()
    End Sub

    Private Sub btnBuscarClienteTC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarClienteTC.Click
        If txtClienteTC.Text <> "" And IsNumeric(txtClienteTC.Text) Then
            LimpiaInfoTarjetaCredito()
            If Not chkCapturaTPV.Checked Then
                ConsultaTarjetaCredito(CType(txtClienteTC.Text, Integer))
            Else
                TPVConsultaCliente()
            End If
            'TODO: Validacion de clientes hijos de edificios adminstrados 13/10/2004
            If GLOBAL_AplicaAdmEdificios Then
                btnAceptarTarjetaCredito.Enabled = True
                Dim oCliente As New SigaMetClasses.cCliente(CType(txtClienteTC.Text, Integer))
                If Not (validacionDeClientesHijosEdificio(oCliente, GLOBAL_AplicaValidacionClienteHijo, _
                        GLOBAL_ClientePadreEdificio)) Then
                    btnAceptarTarjetaCredito.Enabled = False
                End If
            End If
            'Fin de la validacion de edificios admistrados
            If lblTarjetaCredito.Text = "" AndAlso Not chkCapturaTPV.Checked Then
                MessageBox.Show("No existen tarjetas de cr�dito del cliente especificado.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                txtImporteTC.Focus()
            End If
        End If
    End Sub

    Private Sub ManejaFlechas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFechaCheque.KeyDown, MyBase.KeyDown
        If e.KeyCode = Keys.F5 Then
            tabTipoCobro.SelectedTab = tbEfectivoVales
            Exit Sub
        End If
        If e.KeyCode = Keys.F6 Then
            tabTipoCobro.SelectedTab = tbChequeFicha
            Exit Sub
        End If
        If e.KeyCode = Keys.F7 Then
            tabTipoCobro.SelectedTab = tbTarjetaCredito
        End If
        If e.KeyCode = Keys.Down Then
            SendKeys.Send("{TAB}")
        End If
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Then
            Select Case tabTipoCobro.SelectedTab.Name
                Case Is = "tbEfectivoVales"
                    If e.KeyCode = Keys.Right Then tabTipoCobro.SelectedTab = tbChequeFicha
                    If e.KeyCode = Keys.Left Then tabTipoCobro.SelectedTab = tbTarjetaCredito
                Case Is = "tbCheque"
                    If e.KeyCode = Keys.Right Then tabTipoCobro.SelectedTab = tbTarjetaCredito
                    If e.KeyCode = Keys.Left Then tabTipoCobro.SelectedTab = tbEfectivoVales
                Case Is = "tbTarjetaCredito"
                    If e.KeyCode = Keys.Right Then tabTipoCobro.SelectedTab = tbEfectivoVales
                    If e.KeyCode = Keys.Left Then tabTipoCobro.SelectedTab = tbChequeFicha
            End Select
        End If
    End Sub

    Private Sub rbCheque_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCheque.CheckedChanged
        _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.Cheque
        txtDocumento.MaxLength = 7
        _CargaNotaIngreso = False
    End Sub

    Private Sub rbFicha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbFicha.CheckedChanged
        _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.FichaDeposito
        txtDocumento.MaxLength = 10
        _CargaNotaIngreso = False

        'Selecci�n del n�mero de cuenta por medio de un combo 'ver si se parametriza

        cboNumeroCuenta.Visible = rbFicha.Checked
        ComboBanco.Enabled = Not rbFicha.Checked
        If rbFicha.Checked Then
            cboNumeroCuenta.DataSource = DTListaBancos
            cboNumeroCuenta.ValueMember = "Cuenta"
            cboNumeroCuenta.DisplayMember = "NombreCompuesto"
            AddHandler cboNumeroCuenta.SelectedValueChanged, AddressOf cboNumeroCuenta_SelectedValueChanged
            cboNumeroCuenta_SelectedValueChanged(sender, e)
            ComboBanco.BackColor = Color.White
        Else
            RemoveHandler cboNumeroCuenta.SelectedValueChanged, AddressOf cboNumeroCuenta_SelectedValueChanged
        End If

    End Sub

    Private Sub rbNotaCredito_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbNotaCredito.CheckedChanged
        _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.NotaCredito
        txtDocumento.MaxLength = 10
        _CargaNotaIngreso = False

        InactivarControlesNC()
    End Sub

    Private Sub rbNotaIngreso_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbNotaIngreso.CheckedChanged
        _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.NotaIngreso
        txtDocumento.MaxLength = 10
        chkCargarNI.Visible = rbNotaIngreso.Checked
        _CargaNotaIngreso = True

        'Inactivar las opciones de captura de datos si se selecciona carga de nota de ingreso
        InactivaControlesNI(rbNotaIngreso.Checked AndAlso chkCargarNI.Checked)
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        If Trim(txtClienteCheque.Text) <> "" Then
            Dim frmConCliente As New SigaMetClasses.frmConsultaCliente(CType(txtClienteCheque.Text, Integer))
            frmConCliente.ShowDialog()
        End If
    End Sub

    Private Sub txtClienteCheque_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtClienteCheque.Leave
        If Trim(txtClienteCheque.Text) <> String.Empty Then
            Dim oCliente As New SigaMetClasses.cCliente()
            oCliente.Consulta(CType(txtClienteCheque.Text, Integer))
            lblNombre.Text = oCliente.Nombre
            'TODO: Validacion para clientes de adminsitracion de edificios 13/10/2004
            If GLOBAL_AplicaAdmEdificios Then
                btnAceptarChequeFicha.Enabled = True
                If Not (validacionDeClientesHijosEdificio(oCliente, GLOBAL_AplicaValidacionClienteHijo, _
                        GLOBAL_ClientePadreEdificio)) Then
                    btnAceptarChequeFicha.Enabled = False
                End If
            End If
            'Fin de la validacion de cobranza de edificios administrados
            oCliente = Nothing
        End If
    End Sub

    Private Sub LeerCodigoCheque(ByVal strCodigo As String)
        Dim NumeroCuenta As String
        Dim NumeroCheque As String
        NumeroCuenta = Mid(strCodigo, 16, 11)
        NumeroCheque = Mid(strCodigo, 28, 7)

        txtNumeroCuenta.Text = NumeroCuenta
        'txtDocumento.Text = NumeroCheque.Substring(4, 4)
        txtDocumento.Text = NumeroCheque
    End Sub


    Private Sub txtCodigo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigo.Enter
        Me.AcceptButton = btnLeerCodigo
    End Sub


    Private Sub txtCodigo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigo.Leave
        Me.AcceptButton = btnAceptarChequeFicha
    End Sub

    Private Sub btnLeerCodigo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeerCodigo.Click
        On Error Resume Next
        LeerCodigoCheque(txtCodigo.Text)
        txtCodigo.Text = ""
        If Not (txtNumeroCuentaOrigen.Enabled) Then
            txtClienteCheque.SelectAll()
            txtClienteCheque.Focus()
        Else
            txtNumeroCuentaOrigen.SelectAll()
            txtNumeroCuentaOrigen.Focus()
        End If
    End Sub

    Private Sub CargarNI(ByVal strClave As String)
        'Se retira la consulta y se coloca en un procedimiento almacenado
        'Dim strQuery As String = "Select Clave, Total, FMovimiento, Cliente From MovimientoCaja Where Clave = '" & strClave & "'"
        Dim strQuery As String = "spCyCCargaNotaIngreso"
        'Dim da As New SqlDataAdapter(strQuery, SigaMetClasses.LeeInfoConexion(False))
        Dim da As New SqlDataAdapter(strQuery, GLOBAL_connection)
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.Add("@Clave", SqlDbType.VarChar, 20)
        da.SelectCommand.Parameters("@Clave").Value = strClave
        Dim dt As New DataTable("MovimientoCaja")

        Try
            da.Fill(dt)
            If dt.Rows.Count = 1 Then
                If Not IsDBNull(dt.Rows(0).Item("Cliente")) Then txtClienteCheque.Text = CType(dt.Rows(0).Item("Cliente"), Integer).ToString
                txtImporteDocumento.Text = CType(dt.Rows(0).Item("Total"), Decimal).ToString("N")
                dtpFechaCheque.Value = CType(dt.Rows(0).Item("FMovimiento"), Date)
                txtNumeroCuenta.Text = "0"
                txtNumeroCuenta.Enabled = False
                txtClienteCheque.Enabled = False
                txtImporteDocumento.Enabled = False
                dtpFechaCheque.Enabled = False
                ComboBanco.SelectedValue = 0
                ComboBanco.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtDocumento_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDocumento.Leave
        If Me.rbNotaIngreso.Checked And chkCargarNI.Checked = True Then
            CargarNI(txtDocumento.Text)
        Else
            txtClienteCheque.Enabled = True
            txtImporteDocumento.Enabled = True
            'txtNumeroCuenta.Text = ""
            dtpFechaCheque.Enabled = True
        End If
        'Si aplica carga los datos de las notas de cr�dito
        CargaDeNotasCredito()
        '*****
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub chkCargarNI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCargarNI.CheckedChanged
        _CargaNotaIngreso = chkCargarNI.Checked
    End Sub

#Region "Validacion de cliente hijo para edificio "
    'TODO: Validacion de clientes de edificios administrados, cuando se captura una cobranza de edificio administrado
    'verifica que solo se capturen clientes hijos como detalles de la cobranza
    'JAGD 13/10/2004
    Private Function validacionDeClientesHijosEdificio(ByVal oCliente As SigaMetClasses.cCliente, _
        ByVal aplicaValidacionClienteHIjo As Boolean, _
        ByVal clientePadreEdificio As Integer) As Boolean
        If aplicaValidacionClienteHIjo Then
            If Not (oCliente.ClientePadre = clientePadreEdificio) Then
                MessageBox.Show("Ha sido seleccionado el tipo de cobranza de 'Edificios Administrados' por lo" & Chr(13) & _
                            "que se requiere el contrato de un cliente hijo de Administraci�n de Edificios" & Chr(13) & _
                            "asignado al contrato padre " & CStr(clientePadreEdificio), "Validacion del no. de contrato", _
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False 'Devuelve falso si no es un cliente hijo de edificio adminsitado
            Else
                Return True
            End If
        Else
            Return True 'Devuelve verdadero si no est� habiltada la validaci�n de clientes hijos
        End If
    End Function

#End Region

#Region "Validaci�n de nota de cr�dito"
    Private Structure NotaCredito
        Public Factura As Integer
        Public Cliente As Integer
        Public FFactura As Date
        Public Total As Decimal
        Public Status As String
        Public Clave As String
    End Structure

    'Consulta de informaci�n a la base de datos para validaci�n de notas de cr�dito.
    Private Function validaNotaCredito(ByVal Folio As Integer) As NotaCredito
        'Dim connection As New SqlConnection(SigaMetClasses.LeeInfoConexion(False))
        Dim _notaCredito As NotaCredito = Nothing
        Dim connection As SqlConnection = GLOBAL_connection
        Dim cmdSelect As New SqlCommand()
        cmdSelect.CommandText = "spCyCValidaAplicacionNotaCredito"
        cmdSelect.CommandType = CommandType.StoredProcedure
        cmdSelect.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
        cmdSelect.Connection = connection
        Dim reader As SqlDataReader
        Try
            connection.Open()
            reader = cmdSelect.ExecuteReader
            While reader.Read()
                _notaCredito.Factura = CType(reader("Factura"), Integer)
                _notaCredito.Cliente = CType(reader("Cliente"), Integer)
                _notaCredito.FFactura = CType(reader("FFactura"), Date)
                _notaCredito.Total = CType(reader("Total"), Decimal)
                _notaCredito.Status = CType(reader("Status"), String)
                _notaCredito.Clave = CType(reader("Clave"), String)
            End While
            reader.Close()
        Catch ex As SqlException
            MessageBox.Show("Ha ocurrido el siguiente error" & Chr(13) & ex.Number & " " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido el siguiente error" & Chr(13) & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
            cmdSelect.Dispose()
            'connection.Dispose()
        End Try
        Return _notaCredito
    End Function

    'Inactivar los controles para captura de notas de cr�dito
    Private Sub InactivarControlesNC()
        If Not GLOBAL_AplicaValidaci�nNotaCredito Then
            Exit Sub
        End If

        dtpFechaCheque.Enabled = Not rbNotaCredito.Checked
        txtNumeroCuenta.Enabled = Not rbNotaCredito.Checked
        txtClienteCheque.Enabled = Not rbNotaCredito.Checked
        ComboBanco.Enabled = Not rbNotaCredito.Checked
        txtImporteDocumento.Enabled = Not rbNotaCredito.Checked
        btnBusquedaCliente.Enabled = Not rbNotaCredito.Checked

        If Not rbNotaCredito.Checked Then
            ReiniciarControlesNotaCredito()
        End If
    End Sub

    'Reinicializar los controles usados para captura de datos de nota de cr�dito
    Private Sub ReiniciarControlesNotaCredito()
        txtClienteCheque.Text = String.Empty
        txtImporteDocumento.Text = String.Empty
        txtNumeroCuenta.Text = String.Empty
        lblNombre.Text = String.Empty
    End Sub

    'Consulta y valida los datos de la nota de cr�dito y muestra en pantalla en los campos correspondientes
    Private Sub CargaDeNotasCredito()
        If rbNotaCredito.Checked Then
            ReiniciarControlesNotaCredito()
            If Not GLOBAL_AplicaValidaci�nNotaCredito Then
                Exit Sub
            End If
            InactivarControlesNC()
            Dim _notaCredito As NotaCredito
            _notaCredito = validaNotaCredito(CType(txtDocumento.Text, Integer))
            If _notaCredito.Factura > 0 Then
                Select Case _notaCredito.Status.Trim.ToUpper()
                    Case "IMPRESO"
                        'validaci�n de d�as de ajuste para la nota de cr�dito (cierres de mes)
                        Dim mesAnterior As Integer
                        Dim cierreMes As Boolean
                        If FechaOperacion.Day <= GLOBAL_DiasAjuste Then
                            cierreMes = True
                            mesAnterior = DateAdd(DateInterval.Month, -1, FechaOperacion).Month
                        End If

                        txtClienteCheque.Text = _notaCredito.Cliente.ToString()
                        dtpFechaCheque.Value = _notaCredito.FFactura
                        'La nota de cr�dito debe corresponder al mes de la captura de cobranza
                        'o en caso de cierre de mes, debe corresponder al mes en curso o al mes
                        'anterior
                        If Not (_notaCredito.FFactura.Year = FechaOperacion.Year AndAlso _
                            (_notaCredito.FFactura.Month = FechaOperacion.Month OrElse _
                            (cierreMes AndAlso _notaCredito.FFactura.Month = mesAnterior))) Then
                            txtDocumento.Focus()
                            MessageBox.Show("Esta nota de cr�dito no corresponde" & vbCrLf & _
                                "al mes en curso." & _notaCredito.Clave & ".", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If
                        txtImporteDocumento.Text = _notaCredito.Total.ToString()
                        ComboBanco.SelectedValue = 0
                        txtNumeroCuenta.Text = "0"
                        txtClienteCheque_Leave(Nothing, Nothing)
                    Case "APLICADO"
                        txtDocumento.Focus()
                        MessageBox.Show("Esta nota de cr�dito fu� aplicada en" & vbCrLf & _
                            "el movimiento " & _notaCredito.Clave & ".", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Case Else
                        txtDocumento.Focus()
                        MessageBox.Show("Esta nota de cr�dito est� cancelada" & vbCrLf & _
                            "o no ha sido impresa.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End Select
            End If
        End If
    End Sub
#End Region

    Private Sub rbTransferencia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTransferencia.CheckedChanged
        _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.Transferencia
        If Not (rbTransferencia.Checked) Then
            txtNumeroCuentaOrigen.Enabled = False
            ComboBancoOrigen.DataSource = Nothing
            ComboBancoOrigen.Enabled = False
            ComboBancoOrigen.Items.Clear()
            lblBancoOrigen.Text = String.Empty
            lblCtaDestino.Text = String.Empty
        Else
            txtNumeroCuentaOrigen.Enabled = True
            ComboBancoOrigen.Enabled = True
            ComboBancoOrigen.CargaDatos(CargaBancoCero:=True, MostrarClaves:=True, SoloActivos:=True)
            ComboBancoOrigen.SelectedIndex = 0
            lblBancoOrigen.Text = "Banco Origen:"
            lblCtaDestino.Text = "No. Cuenta Origen:"
        End If
    End Sub

    Private Sub btnSFBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSFBuscar.Click
        CleanSaldoAFavor()
        'Dim cnSigamet As New SqlClient.SqlConnection(ConString)
        Dim cnSigamet As SqlClient.SqlConnection = GLOBAL_connection
        Dim consultaSaldoAFavor As New CyCSaldoAFavor.frmSaldosAFavor(cnSigamet, txtSFClave.Text, _
            CType(Val(txtSFCliente.Text), Integer), CType(Val(txtSFA�oAtt.Text), Integer), _
            CType(Val(txtSFFolioAtt.Text), Integer))
        If consultaSaldoAFavor.ShowDialog() = DialogResult.OK Then
            lblSFA�oCobro.Text = consultaSaldoAFavor.AnioCobro.ToString
            lblSFCobro.Text = consultaSaldoAFavor.Cobro.ToString
            lblSFCliente.Text = consultaSaldoAFavor.Cliente.ToString
            lblSaldoAFavorNombre.Text = consultaSaldoAFavor.Nombre
            lblSFTipo.Text = consultaSaldoAFavor.TipoDocumento
            lblSFImporte.Text = consultaSaldoAFavor.Importe.ToString
            lblSFMovimientoOrigen.Text = consultaSaldoAFavor.MovimientoOrigen.ToString
        End If
    End Sub

    Private Sub CleanSaldoAFavor()
        lblSFA�oCobro.Text = String.Empty
        lblSFCobro.Text = String.Empty
        lblSFCliente.Text = String.Empty
        lblSaldoAFavorNombre.Text = String.Empty
        lblSFTipo.Text = String.Empty
        lblSFImporte.Text = String.Empty
        lblSFMovimientoOrigen.Text = String.Empty
    End Sub

    Private Sub btnAceptarSF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptarSF.Click
        'Validar que el tipo de cobro seleccionado se puede capturar en este tipo de movimiento JAG 23-01-2008
        If GLOBAL_ValidarTipoCobro Then
            If Not ValidarTipoCobro(_TipoMovimientoCaja, SigaMetClasses.Enumeradores.enumTipoCobro.SaldoAFavor) Then
                Exit Sub
            End If
        End If

        Dim frmCaptura As frmCapCobranzaDoc
        If Not _EsRelacionCobranza Then
            frmCaptura = New frmCapCobranzaDoc(_TipoMovimientoCaja, _SoloDocumentosCartera, _ListaCobros)
        Else
            frmCaptura = New frmCapCobranzaDoc(_TipoMovimientoCaja, _SoloDocumentosCartera, _ListaCobros, _RelacionCobranza)
        End If
        frmCaptura.TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.SaldoAFavor
        frmCaptura.ImporteCobro = CType(lblSFImporte.Text, Decimal)

        'Para control de saldos a favor (Le pasamos el cliente del cheque para validar que se pueda capturar) 04/04/2005
        frmCaptura.Cliente = CType(Val(lblSFCliente.Text), Integer)
        'TODO: Hacer la consulta de la tabla de clientes relacionados en esta parte, habilitar una operaci�n para permitir la captura libre de saldos a favor
        Dim ClientesRelacionados As New CyCSaldoAFavor.saldoAFavor()
        frmCaptura.ClientesRelacionados(CType(Val(lblSFCliente.Text), Integer)) = _
            ClientesRelacionados.ClientesRelacionados(CType(Val(lblSFCliente.Text), Integer), GLOBAL_connection)

        If frmCaptura.ShowDialog() = DialogResult.OK Then
            With Cobro
                .Consecutivo = _Consecutivo
                .AnoCobro = CType(FechaOperacion.Year, Short)
                .TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.SaldoAFavor
                .AnioCobroOrigen = CType(Val(lblSFA�oCobro.Text), Short)
                .CobroOrigen = CType(Val(lblSFCobro.Text), Integer)
                .Total = frmCaptura.ImporteCobro
                .Saldo = 0
                .Cliente = CType(Val(lblSFCliente.Text), Integer)
                .Observaciones = "ABONO DE SALDO A FAVOR"
                .ListaPedidos = frmCaptura.ListaCobroPedido
                ImporteTotalCobro = .Total
            End With
            DialogResult = DialogResult.OK
        End If
    End Sub

    Private Sub BuscaBanco(ByVal NumeroCuenta As String)
        Dim cuentaCap As String = NumeroCuenta
        If rbFicha.Checked AndAlso (cuentaCap.Length >= 5) Then
            Dim dr As Data.DataRow
            For Each dr In DTListaBancos.Rows
                Dim cuenta As String = CType(dr("Cuenta"), String).Trim
                If cuentaCap.Substring(cuentaCap.Length - 5) = cuenta.Substring(cuenta.Length - 5) Then
                    ComboBanco.SelectedValue = CType(dr("Banco"), Integer)
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub cboNumeroCuenta_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If rbFicha.Checked Then
            txtNumeroCuenta.Text = CType(cboNumeroCuenta.SelectedValue, String).Trim
            BuscaBanco(txtNumeroCuenta.Text.Trim)
        End If
    End Sub

#Region "Pagos con recibo TP TC"

    Private Sub chkCapturaTPV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCapturaTPV.CheckedChanged
        LimpiaInfoTarjetaCredito()

        Me.lblTarjetaCredito.Visible = Not chkCapturaTPV.Checked
        Me.lblBancoNombre.Visible = Not chkCapturaTPV.Checked
        Me.lblBanco.Visible = Not chkCapturaTPV.Checked

        Me.txtNumeroTarjeta.Visible = chkCapturaTPV.Checked
        Me.comboBancoTDC.Visible = chkCapturaTPV.Checked
        If chkCapturaTPV.Checked Then
            lblTxtTarjeta.Text = "No. Autorizaci�n"
            Me.grpTarjetaCredito.Controls.Add(Me.comboBancoTDC)
            Me.grpTarjetaCredito.Controls.Add(Me.txtNumeroTarjeta)
            AddHandler comboBancoTDC.SelectedIndexChanged, AddressOf cboBanco_SelectedIndexChanged
            cboBanco_SelectedIndexChanged(sender, e)
        Else
            lblTxtTarjeta.Text = "No. Tarjeta:"
            Me.grpTarjetaCredito.Controls.Remove(Me.comboBancoTDC)
            Me.grpTarjetaCredito.Controls.Remove(Me.txtNumeroTarjeta)
            RemoveHandler comboBancoTDC.SelectedIndexChanged, AddressOf cboBanco_SelectedIndexChanged
            Me.lblTarjetaCredito.Text = String.Empty
            Me.lblBancoNombre.Text = String.Empty
            Me.lblBanco.Text = String.Empty
        End If
    End Sub

    Private Sub txtTarjetaCredito_Changed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumeroTarjeta.TextChanged
        Me.lblTarjetaCredito.Text = txtNumeroTarjeta.Text
    End Sub

    Private Sub cboBanco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.lblBanco.Text = CType(comboBancoTDC.SelectedValue, String)
    End Sub

    Private Sub TPVConsultaCliente()
        Dim oCliente As New SigaMetClasses.cCliente()
        oCliente.Consulta(CType(txtClienteTC.Text, Integer))
        lblClienteNombre.Text = oCliente.Nombre
    End Sub

#End Region

    Private Sub btnBusquedaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBusquedaCliente.Click
        Dim buscaClientePadre As New SigaMetClasses.BusquedaCliente(True)
        buscaClientePadre.ShowDialog()
        If buscaClientePadre.DialogResult = DialogResult.OK Then
            txtClienteCheque.Text = CStr(buscaClientePadre.Cliente)
            txtClienteCheque_Leave(sender, e)
        End If
    End Sub

    Private Function mensajeNumeroCuenta(ByVal minimo As Byte, ByVal maximo As Byte) As String
        Dim mensaje As String = "El n�mero de cuenta debe ser de "

        If Not minimo = maximo Then
            mensaje &= minimo.ToString() & " d�gitos como m�nimo y " & maximo.ToString() + " como m�ximo"
        Else
            mensaje &= minimo.ToString() & " d�gitos"
        End If

        Return mensaje
    End Function

    'Consulta de los n�meros de cuenta que han sido usados por un cliente en pagos previos con cheque
    Private Function numeroCuentaClienteValido(ByVal Connection As SqlConnection, _
        ByVal Cliente As Integer, _
        ByVal Banco As Short, _
        ByVal Cuenta As String) As Boolean

        Dim _numeroCuentaCliente As DataTable
        Dim _ctDr As DataRow
        Dim _encontrado As Boolean = False

        Try
            _numeroCuentaCliente = Main.NumeroCuentaCliente(SigaMetClasses.DataLayer.Conexion, CType(txtClienteCheque.Text, Integer), _
                                                CType(ComboBanco.SelectedValue, Short))
            For Each _ctDr In _numeroCuentaCliente.Rows
                _encontrado = (CType(_ctDr("NumeroCuenta"), String).Trim() = Cuenta.Trim)
                If _encontrado Then
                    Exit For
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try

        Return _encontrado
    End Function
    '*****

    'Validaci�n de notas de cr�dito capturadas
    Private Function validarNotadeIngreso(ByVal ClaveNI As String) As Boolean
        Dim _notaExistente As Boolean
        Dim _notaValida As Boolean

        Dim _passValidacion As Boolean = True

        Try
            _notaValida = Main.ValidacionNotaIngresoValidada(SigaMetClasses.DataLayer.Conexion, txtDocumento.Text)
            _notaExistente = Main.ValidacionNotaIngresoExistente(SigaMetClasses.DataLayer.Conexion, txtDocumento.Text)
        Catch ex As Exception
            Throw ex
        End Try

        'Verificar si la nota de ingreso (movimiento NI) ya fu� validada.
        If Not _notaValida Then
            MessageBox.Show("Esta nota de ingreso no ha sido validada, no podr� capturarla" & vbCrLf & _
                "Verifique.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            _passValidacion = False
            Exit Function
        End If

        'Verificar si la nota de ingreso ya fu� capturada en otro movimiento
        If _notaExistente Then
            MessageBox.Show("Esta nota de ingreso ya fu� capturada en otro movimiento," & vbCrLf & _
                "no podr� capturarla. Verifique.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            _passValidacion = False
            Exit Function
        End If

        Return _passValidacion
    End Function

    'Inhabilitar los controles de captura de nota de cr�dito
    Private Sub InactivaControlesNI(ByVal Activar As Boolean)
        If Activar Then
            txtDocumento.Select()
        End If

        Activar = Not Activar
        txtNumeroCuenta.Text = "0"
        txtNumeroCuenta.Enabled = Activar
        txtClienteCheque.Enabled = Activar
        txtImporteDocumento.Enabled = Activar
        dtpFechaCheque.Enabled = Activar
        ComboBanco.SelectedValue = 0
        ComboBanco.Enabled = Activar
    End Sub
    '*****

    'Validar el tipo de cobro con el tipo de movimiento
    Private Function ValidarTipoCobro(ByVal TipoMovimientoCaja As Byte, ByVal TipoCobro As SigaMetClasses.Enumeradores.enumTipoCobro) As Boolean
        Dim _passing As Boolean = False
        Dim _tipoCobro As Byte = CType(TipoCobro, Byte)

        Try
            _passing = Main.ValidacionTipoCobroTipoMovimientoCaja(SigaMetClasses.DataLayer.Conexion, TipoMovimientoCaja, _tipoCobro)
            If Not _passing Then
                MessageBox.Show("No puede utilizar esta forma de pago" & vbCrLf & "en el movimiento que est� captuando.", Me.Text, _
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message, Me.Text, _
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        Return _passing
    End Function
    '*****
End Class