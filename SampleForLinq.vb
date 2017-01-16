''' <summary>
''' MEMO:
''' 実はLinqToSqlでのデータ更新を楽にしたくて作ったPropertyMerger
''' これはあくまで「こんな感じ」で書いたから動かないけど、だいたいこんな感じ
''' </summary>
''' <remarks></remarks>

Module SampleForLinq

    <Table(Name:="SomethingClass")> _
    Public Class SomethingClass
        <Column(Storage:="_Prop1", DbType:="Int NOT NULL", IsPrimaryKey:=True, IsDbGenerated:=True)> _
        Public Property Prop1 As String
        <Required()> _
        Public Property Prop2 As String
    End Class

    Private Function SaveForLinq()
        Dim db As New DataContext(CONNECTIONSTRING)
        Dim table As System.Data.Linq.Table(Of SomethingClass) = db.GetTable(Of SomethingClass)()

        Dim changeData As New SomethingClass() With {
                .Prop1 = ":)",
                .Prop2 = ":D"
            }

        Dim target = (From s In table Where String.IsNullOrEmpty(s.Prop1)).Single

        Dim merger As New PropertyMerger(GetType(SomethingClass))
        With merger
            .SetField({"Prop2"})
            .SetTarget(target)
            .SetData(table)
            .Merge()
        End With

        db.SubmitChanges()

        Return merger.GetMergeData()
    End Function

End Module
