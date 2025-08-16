#ESTA TODO EN LOCAL ASÍ QUE HAY QUE HACER ESTO


#Setup local db (Sql server)
 docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-CU21-ubuntu-20.04

Microsoft SQL server (TCP/IP)
Librería: SQLOLEDB

 Nombre del host: localhost
 Usuario: sa
 Contraseña: yourStrong(!)Password
 Puerto: 1433

Crear DB

Para crear la database hay que ir al archivo "GatosMySQL.sql" y pegar el contenido en el programa de bases de datos
 
 Eliminar DB
 
 DROP DATABASE GatosDB; 
