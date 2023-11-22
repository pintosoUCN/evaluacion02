# Backend y Frontend Listado de productos

Este repositorio contiene el código fuente para el backend en ASP.NET Core y el frontend en React para realizar un CRUD de productos.


## Configuración de la Base de Datos

1. Asegurate de tener instalado SQL Server.

2. Crea una base de datos

3. Abre el archivo `appsettings.json` en la carpeta del proyecto backend (`backend/`).

4. Reemplaza la cadena de conexión en la sección `"ConnectionStrings"` con la información de tu servidor SQL Server:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=<nombre_servidor>;Database=<nombre_base_datos>;Trusted_Connection=True;TrustServerCertificate=True;"
   },

5. En tu terminal, navega a la carpeta del proyecto backend y ejecuta las migraciones para crear la base de datos:

    ```bash
    cd backend
    dotnet ef database update
    ```

## Configuración del Backend (ASP.NET Core)

1. Abre el proyecto en tu entorno de desarrollo preferido (Visual Studio, Visual Studio Code, etc.).

2. Asegúrate de tener [.NET SDK](https://dotnet.microsoft.com/download) instalado.

3. Restaura las dependencias del proyecto:

    ```bash
    dotnet restore
    ```

4. Ejecuta la aplicación:

    ```bash
    dotnet run
    ```

5. La API estará disponible en `http://localhost:5065/swagger/index.html`.

## Configuración del Frontend (React)

1. Abre la carpeta del frontend en tu terminal.

    ```bash
    cd frontend
    ```

2. Asegúrate de tener [Node.js](https://nodejs.org/) y [npm](https://www.npmjs.com/) instalados.

3. Instala las dependencias del proyecto:

    ```bash
    npm install
    ```

4. Inicia la aplicación React:

    ```bash
    npm start
    ```

5. El frontend estará disponible en `http://localhost:3000/products` por defecto.