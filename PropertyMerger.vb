Imports System.Reflection

Public Class PropertyMerger
    Private Property type As Type
    Private Property propertyList As String()
    Private Property target As New Object
    Private Property data As New Object
    Private Property mergeData As New Object

    Sub New(type)
        Me.type = type
    End Sub

    ''' <summary>
    ''' 更新元データのセット
    ''' </summary>
    ''' <param name="target">Object</param>
    ''' <returns>Me</returns>
    ''' <remarks></remarks>
    Public Function SetTarget(target As Object)
        Me.target = target
        Me.mergeData = target
        Return Me
    End Function

    ''' <summary>
    ''' 更新する項目を追加
    ''' </summary>
    ''' <param name="fields">String()</param>
    ''' <returns>Me</returns>
    ''' <remarks></remarks>
    Public Function SetField(fields As String())
        Me.propertyList = fields
        Return Me
    End Function

    ''' <summary>
    ''' 更新データのセット
    ''' </summary>
    ''' <param name="data">Object</param>
    ''' <returns>Me</returns>
    ''' <remarks></remarks>
    Public Function SetData(data As Object)
        Me.data = data
        Return Me
    End Function

    ''' <summary>
    ''' targetにdataをマージする
    ''' </summary>
    ''' <remarks></remarks>
    Public Function Merge()
        For Each prop As String In propertyList
            Dim propInfo As PropertyInfo = type.GetProperty(prop)
            Dim val As Object = propInfo.GetValue(data, Nothing)
            propInfo.SetValue(mergeData, val, Nothing)
        Next
        Return Me.mergeData
    End Function

    ''' <summary>
    ''' マージ後のデータを返す
    ''' </summary>
    ''' <returns>Me</returns>
    ''' <remarks>Object</remarks>
    Public Function GetMergeData()
        Return Me.mergeData
    End Function

End Class
