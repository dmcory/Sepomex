Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Migrations
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.IO
Imports System.Linq
Imports Excel

Namespace Migrations

    Friend NotInheritable Class Configuration
        Inherits DbMigrationsConfiguration(Of Models.Web_APIContext)

        Public Sub New()
            AutomaticMigrationsEnabled = False
        End Sub

        Protected Overrides Sub Seed(context As Models.Web_APIContext)
            'Read xls file
            Dim baseDir As String = AppDomain.CurrentDomain.BaseDirectory.Replace("\bin\", String.Empty) + "\App_Data"
            For Each fle As String In Directory.GetFiles(baseDir, "*.xls")
                'Get the DataSet
                Dim ds As New DataSet
                ds = Sheet(fle)

                'Read through all the sheets of the excel and bulk insert it
                Dim cn As New SqlConnection(ConfigurationManager.ConnectionStrings("Web_APIContext").ConnectionString)
                For i As Integer = 1 To ds.Tables.Count - 1
                    Dim dt As DataTable = ds.Tables(i)
                    Dim objBulk As New SqlBulkCopy(cn)
                    With objBulk
                        .DestinationTableName = "zip_codes"
                        .ColumnMappings.Add("d_codigo", "Cp")
                        .ColumnMappings.Add("d_asenta", "Asentamiento")
                        .ColumnMappings.Add("d_tipo_asenta", "Tipo_Asentamiento")
                        .ColumnMappings.Add("d_mnpio", "Municipio")
                        .ColumnMappings.Add("d_estado", "Estado")
                        .ColumnMappings.Add("d_ciudad", "Ciudad")
                        .ColumnMappings.Add("c_tipo_asenta", "Clave_Tipo_Asentamiento")
                        .ColumnMappings.Add("c_mnpio", "Clave_Municipio")
                        .ColumnMappings.Add("c_cve_ciudad", "Clave_Ciudad")
                        .ColumnMappings.Add("d_zona", "Zona")
                        cn.Open()
                        objBulk.WriteToServer(dt)
                        cn.Close()
                    End With
                Next
            Next
        End Sub

        Public Function Sheet(ByVal fle As String) As DataSet
            Dim stream As FileStream = File.Open(fle, FileMode.Open, FileAccess.Read)
            Dim excelReader As IExcelDataReader = ExcelReaderFactory.CreateBinaryReader(stream)
            excelReader.IsFirstRowAsColumnNames = True
            Return excelReader.AsDataSet
        End Function

    End Class

End Namespace
