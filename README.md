		DETALLES DE LA APLICACION

La aplicacion creada usa ASP.NET CORE v5, Enity Framework 5.

Se usa tambien para el manejo de roles sesiones propias de la libreria ASPNETCORE.SESSION

BASES DE DATOS:
Toda la Data se encuentra creada con SQL Server Express, y el archivo del SQuema se encuentra
en �ste mismo directorio en el archivo:
-	SQUEMA_BANCABASICA.sql

-	Para el manejo de c�clculos cuando se hace un movimiento de d�bito o cr�dito,
	se cre� un trigger (insert, update) sobre la tabla de movimeintos para calcular
	los saldos y que no permita hacer transacciones con saldo negativo, para ello se
	uso transaccionalidad en dicho trigger.

Los objetos (Tablas) de la base de datos estan creados con Entity Framework (Code Fisrt).

CADENA CONEXION BDD:
La cadena de conexion se encuentra en la ra�z de �ste directorio en el archivo:
-	appsettings.json
		  "ConnectionStrings": {
			"DefaultConnection": "Server=(LocalDb)\\MSSQLLocalDB;Database=BancaBasicaDB;Trusted_Connection=true;"

		