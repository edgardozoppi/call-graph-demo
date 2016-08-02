
Imports System.Collections.Generic
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Threading.Tasks

Namespace Demo.Collections
	Module Extensions
		<Extension>
		Public Function Where(Of T)(self As IEnumerable(Of T), condition As Func(Of T, Boolean)) As IEnumerable(Of T)
			Dim result = New List(Of T)()

			For Each elem In self
				If condition(elem) Then
					result.Add(elem)
				End If
			Next

			Return result
		End Function

		<Extension>
		Public Function [Select](Of T, R)(self As IEnumerable(Of T), action As Func(Of T, R)) As IEnumerable(Of R)
			Dim result = New List(Of R)()

			For Each elem In self
				Dim re = action(elem)
				result.Add(re)
			Next

			Return result
		End Function

		<Extension>
		Public Function Count(Of T)(self As IEnumerable(Of T)) As Integer
			Dim result = 0

			For Each elem In self
				result += 1
			Next

			Return result
		End Function
	End Module
End Namespace
