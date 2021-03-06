Public Class frmConsultaMovimientos
    Inherits SigaMetClasses.ConsultaMovimientos

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New(4, Main.GLOBAL_IDUsuario, Main.GLOBAL_IDEmpleado)

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

#End Region

    Public Overrides Sub Capturar()
        MyBase.Capturar()
        Cursor = Cursors.WaitCursor
        Dim VentanaCapCobranza As New frmCapCobranza()
        'VentanaCapCobranza = New frmCapCobranza()
        With VentanaCapCobranza
            .Text = "Captura de cobranza"
            .StartPosition = FormStartPosition.CenterScreen
            Cursor = Cursors.Default
            If .ShowDialog = DialogResult.OK Then
                CargaDatos()
            End If
        End With
    End Sub

    Public Overrides Sub Imprimir(ByVal Caja As Byte, ByVal FOperacion As Date, ByVal Folio As Integer, ByVal Consecutivo As Integer)
        Cursor = Cursors.WaitCursor
        Dim frmRep As New frmConsultaReporte(frmConsultaReporte.enumTipoReporte.CombrobanteCaja, Caja, FOperacion, Folio, Consecutivo)
        frmRep.ShowDialog()
        Cursor = Cursors.Default

    End Sub

    Private Sub frmConsultaMovimientos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaDatos()
        Me.PermiteCapturar = GLOBAL_CapturaPermitida
        Me.PermiteModificar = GLOBAL_CapturaPermitida


    End Sub

    Public Overrides Sub Modificar()
        Cursor = Cursors.WaitCursor
        Dim oCapMov As frmCapCobranza
        oCapMov = New frmCapCobranza(Me.Clave)
        oCapMov.Text = "Modificación del movimiento: " & Me.Clave

        If oCapMov.ShowDialog() = DialogResult.OK Then
            Me.CargaDatos()
        End If
        Cursor = Cursors.Default

    End Sub
End Class
