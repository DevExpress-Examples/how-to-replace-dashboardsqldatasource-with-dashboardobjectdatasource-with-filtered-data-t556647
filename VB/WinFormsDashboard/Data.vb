﻿Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Data
Imports System.Drawing
Imports System.IO

Namespace DataLibrary
	Public Class DataItem
		Public Property OrderDate() As Date
		Public Property Total() As Decimal
		Public Property Target() As Decimal
		Public Property SalesPersons() As String
		Public Property Category() As String
		Public Property Product() As String
		Public Property Country() As String
		Public Property Latitude() As Double
		Public Property Longitude() As Double
		Public Property CategoryImage() As Image
	End Class

	Public Class DataProvider
		Public Shared ReadOnly Property DataSourceName() As String
			Get
				Return "Default Datasource"
			End Get
		End Property

		Public Shared Function GetRandomDataList(ByVal rowCount As Integer) As List(Of DataItem)
			Dim list As New List(Of DataItem)()
			Dim salesPersons() As String = { "Andrew Fuller", "Michael Suyama", "Robert King", "Nancy Davolio", "Margaret Peacock", "Laura Callahan", "Steven Buchanan", "Janet Leverling" }
			Dim lattitudes() As Double = {45.806064,36.247343,39.439133,45.462800,29.232212,33.287802,44.905274,40.866558 }
			Dim longitudes() As Double = { -123.536470, -108.394521, -76.929677, -85.279286, -81.587880, -117.535146, -68.843740, -111.998036 }

			Dim catergories() As String = { Nothing, "Category 1", "Category 2", "Category 3", "Category 4" }
			Dim products() As String = { "Aaa", "Bbb", "Ccc", "Ddd", "Eee", "Fff" }
			Dim countriesAll() As String = {"French Guiana","Afghanistan","Angola","Albania","United Arab Emirates","Argentina","Armenia","Fr. S. Antarctic Lands","Australia","Austria","Azerbaijan","Burundi","Belgium","Benin","Burkina Faso","Bangladesh","Bulgaria","Bahamas","Bosnia and Herz.","Belarus","Belize","Bolivia","Brazil","Brunei","Bhutan","Botswana","Central African Rep.","Canada","Switzerland","Chile","China","Cote d'Ivoire","Cameroon","Dem. Rep. Congo","Congo","Colombia","Costa Rica","Cuba","Czech Rep.","Germany","Djibouti","Denmark","Dominican Rep.","Algeria","Ecuador","Egypt","Eritrea","Spain","Estonia","Ethiopia","Finland","Fiji","Falkland Is.","Gabon","United Kingdom","Georgia","Ghana","Guinea","Gambia","Guinea-Bissau","Eq. Guinea","Greece","Greenland","Guatemala","Guyana","Honduras","Croatia","Haiti","Hungary","Indonesia","India","Ireland","Iran","Iraq","Iceland","Israel","Italy","Jamaica","Jordan","Japan","Kazakhstan","Kenya","Kyrgyzstan","Cambodia","Korea","Kosovo","Kuwait","Lao PDR","Lebanon","Liberia","Libya","Sri Lanka","Lesotho","Lithuania","Luxembourg","Latvia","Morocco","Moldova","Madagascar","Mexico","Macedonia","Mali","Myanmar","Montenegro","Mongolia","Mozambique","Mauritania","Malawi","Malaysia","Namibia","New Caledonia","Niger","Nigeria","Nicaragua","Netherlands","Norway","Nepal","New Zealand","Oman","Pakistan","Panama","Peru","Philippines","Papua New Guinea","Poland","Puerto Rico","Dem. Rep. Korea","Portugal","Paraguay","Palestine","Qatar","Romania","Rwanda","W. Sahara","Saudi Arabia","Sudan","S. Sudan","Senegal","Solomon Is.","Sierra Leone","El Salvador","Serbia","Suriname","Slovakia","Slovenia","Sweden","Swaziland","Syria","Chad","Togo","Thailand","Tajikistan","Turkmenistan","Timor-Leste","Trinidad and Tobago","Tunisia","Turkey","Taiwan","Tanzania","Uganda","Ukraine","Uruguay","United States","Uzbekistan","Venezuela","Vietnam","Vanuatu","Yemen","South Africa","Zambia","Zimbabwe","Russia","Cyprus","Somalia","France"}
			Dim countriesEurope() As String = { "Albania", "Aland", "Andorra", "Austria", "Belgium", "Bulgaria", "Bosnia and Herz.", "Belarus", "Switzerland", "Czech Rep.", "Germany", "Denmark", "Spain", "Estonia", "Finland", "France", "Faeroe Is.", "United Kingdom", "Guernsey", "Greece", "Croatia", "Hungary", "Isle of Man", "Ireland", "Iceland", "Italy", "Jersey", "Kosovo", "Liechtenstein", "Lithuania", "Luxembourg", "Latvia", "Monaco", "Moldova", "Macedonia", "Malta", "Montenegro", "Netherlands", "Norway", "Poland", "Portugal", "Romania", "San Marino", "Serbia", "Slovakia", "Slovenia", "Sweden", "Ukraine", "Vatican", "Russia" }
			Dim r As New Random()

			Dim [date] As Date = Date.Today
			For i As Integer = 0 To rowCount - 1
				[date] = [date].AddDays(r.Next(8))
				Dim total As Decimal = 3500 - r.Next(1000)
				Dim categoryIndex As Integer = r.Next(catergories.Length)
				Dim salesPersonIndex As Integer = r.Next(salesPersons.Length)
				list.Add(New DataItem() With {.OrderDate = [date], .Total = total, .Target = total + r.Next(1000), .Category = catergories(categoryIndex), .Product = GetNext(r, products), .SalesPersons = salesPersons(salesPersonIndex), .Latitude = lattitudes(salesPersonIndex), .Longitude = longitudes(salesPersonIndex), .Country = GetNext(r, countriesAll)})
			Next i

			Return list
		End Function



		Private Shared Function GetNext(ByVal r As Random, ByVal sourceStr() As String) As String
			Return sourceStr(r.Next(sourceStr.Length))
		End Function

		Public Shared Function GetStaticDataList() As List(Of DataItem)
			Dim list As New List(Of DataItem)()
			Dim baseDate As Date = Date.Today
			list.Add(New DataItem() With {.OrderDate = baseDate, .Total = 100, .Category = "", .Product = ""})
			list.Add(New DataItem() With {.OrderDate = baseDate.AddMonths(1), .Total = 90, .Category = "", .Product = ""})
			list.Add(New DataItem() With {.OrderDate = baseDate.AddMonths(2), .Total = 160, .Category = "", .Product = ""})
			list.Add(New DataItem() With {.OrderDate = baseDate.AddMonths(3), .Total = 70, .Category = "", .Product = ""})
			list.Add(New DataItem() With {.OrderDate = baseDate.AddMonths(4), .Total = 130, .Category = "", .Product = ""})

			list.Add(New DataItem() With {.OrderDate = baseDate, .Total = 120, .Category = "Bbb", .Product = "Z"})
			list.Add(New DataItem() With {.OrderDate = baseDate.AddMonths(1), .Total = 90, .Category = "Bbb", .Product = "Z"})
			list.Add(New DataItem() With {.OrderDate = baseDate.AddMonths(2), .Total = 120, .Category = "Bbb", .Product = "Y"})
			list.Add(New DataItem() With {.OrderDate = baseDate.AddMonths(3), .Total = 50, .Category = "Bbb", .Product = "X"})
			list.Add(New DataItem() With {.OrderDate = baseDate.AddMonths(4), .Total = 100, .Category = "Bbb", .Product = "Z"})

			list.Add(New DataItem() With {.OrderDate = baseDate, .Total = 90, .Category = "Ccc", .Product = "Y"})
			list.Add(New DataItem() With {.OrderDate = baseDate.AddMonths(1), .Total = 40, .Category = "Ccc", .Product = "Z"})
			list.Add(New DataItem() With {.OrderDate = baseDate.AddMonths(2), .Total = 100, .Category = "Ccc", .Product = "X"})
			list.Add(New DataItem() With {.OrderDate = baseDate.AddMonths(3), .Total = 170, .Category = "Ccc", .Product = "X"})
			list.Add(New DataItem() With {.OrderDate = baseDate.AddMonths(4), .Total = 100, .Category = "Ccc", .Product = "Z"})

			baseDate = baseDate.AddYears(1)
			list.Add(New DataItem() With {.OrderDate = baseDate, .Total = 140, .Category = "", .Product = ""})
			list.Add(New DataItem() With {.OrderDate = baseDate.AddMonths(1), .Total = 30, .Category = "", .Product = ""})
			list.Add(New DataItem() With {.OrderDate = baseDate.AddMonths(2), .Total = 110, .Category = "", .Product = ""})
			list.Add(New DataItem() With {.OrderDate = baseDate.AddMonths(3), .Total = 50, .Category = "", .Product = ""})
			list.Add(New DataItem() With {.OrderDate = baseDate.AddMonths(4), .Total = 90, .Category = "", .Product = ""})

			list.Add(New DataItem() With {.OrderDate = baseDate, .Total = 120, .Category = "Bbb", .Product = "Y"})
			list.Add(New DataItem() With {.OrderDate = baseDate.AddMonths(1), .Total = 90, .Category = "Bbb", .Product = "Y"})
			list.Add(New DataItem() With {.OrderDate = baseDate.AddMonths(2), .Total = 40, .Category = "Bbb", .Product = "X"})
			list.Add(New DataItem() With {.OrderDate = baseDate.AddMonths(3), .Total = 30, .Category = "Bbb", .Product = "Z"})
			list.Add(New DataItem() With {.OrderDate = baseDate.AddMonths(4), .Total = 120, .Category = "Bbb", .Product = "Z"})

			list.Add(New DataItem() With {.OrderDate = baseDate, .Total = 190, .Category = "Ccc", .Product = "Z"})
			list.Add(New DataItem() With {.OrderDate = baseDate.AddMonths(1), .Total = 140, .Category = "Ccc", .Product = "Y"})
			list.Add(New DataItem() With {.OrderDate = baseDate.AddMonths(2), .Total = 140, .Category = "Ccc", .Product = "X"})
			list.Add(New DataItem() With {.OrderDate = baseDate.AddMonths(3), .Total = 60, .Category = "Ccc", .Product = "Y"})
			list.Add(New DataItem() With {.OrderDate = baseDate.AddMonths(4), .Total = 130, .Category = "Ccc", .Product = "X"})


			Return list
		End Function

		Public Shared Function GetDataTable(ByVal rowCount As Integer) As DataTable
			Dim dt As DataTable = CreateTable()
			For Each d As DataItem In GetRandomDataList(rowCount)
				dt.Rows.Add(New Object() { d.OrderDate, d.Total, d.Target, d.SalesPersons, d.Category, d.Product, d.Country })
			Next d
			Return dt
		End Function

		Private Shared Function CreateTable() As DataTable
			Dim dt As New DataTable()
			dt.Columns.Add("OrderDate", GetType(Date))
			dt.Columns.Add("Total", GetType(Decimal))
			dt.Columns.Add("Target", GetType(Decimal))
			dt.Columns.Add("SalesPerson", GetType(String))
			dt.Columns.Add("Category", GetType(String))
			dt.Columns.Add("Product", GetType(String))
			dt.Columns.Add("Country", GetType(String))
			Return dt
		End Function
	End Class
End Namespace


