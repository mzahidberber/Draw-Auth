<img src="drawcad.png">
<hr>
<h6 align="center">
  <a href="https://docs.drawprogram.org">DrawCAD |</a>
  <a href="https://docs.drawprogram.org/doc">Doc |</a>
  <a href="https://docs.drawprogram.org/api">Api |</a>
  <a href="https://docs.drawprogram.org/geo">Geo |</a>
  <a href="https://docs.drawprogram.org/auth">Auth</a>
</h6>
<hr>

<div align="center">
    <img src="auth.png" style="width:70%">
</div>

Auth service is designed to generate tokens for authentication and authorization transactions, and to store and organize token information. The service with a layered architecture structure is an asp.net cor web api project. It consists of API, business, dataaccess and core layers. It is a restapi type of service.

<p>
    Technologies;
    <div style="max-width:36rem;">
        <table>
            <tbody>
                <tr>
                    <td scope="row">Data Access :</td>
                    <td>Entity Framework Core</td>
                </tr>
                <tr>
                    <td scope="row">IOC Container : </td>
                    <td>Ninject</td>
                </tr>
                <tr>
                    <td scope="row">Validation : </td>
                    <td colspan="2">Fluent Validation</td>
                </tr>
                <tr>
                    <td scope="row">Mapping : </td>
                    <td colspan="2">AutoMapper</td>
                </tr>
                <tr>
                    <td scope="row">User transection : </td>
                    <td colspan="2">Identity</td>
                </tr>
            </tbody>
        </table>
    </div>
</p>



<h3>Quick Start</h3>
<p>You can download the image from dockerhub to use it.</p>

```
docker pull mzahidberber/drawauth:latest
```

<p>Or you can download the source code and create the image yourself.</p>

```
docker build -t drawauth -f AuthServer.API/Dockerfile .
```

<p>Before starting the container, you must start the mysql server for the data.</p>

```
docker run --name data -p 3306:3306 --env MYSQL_ROOT_PASSWORD:123456 --network=draw -v <your-path>:/var/lib/mysql  mysql
```

<p>Before starting the container, you must start the mysql server for the data.</p>

```
docker run --name auth -p 5002:80 --env dbHost=data --env dbPort=3306 --env dbName=drawdb --env dbPassword=123456 --network=draw  drawauth
```