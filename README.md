# 🌟 Example of ADO.NET CRUD Web API with JWT  

🚀 **Contoh implementasi API CRUD menggunakan ADO.NET dan ASP.NET dengan autentikasi JWT.**  
API ini mencakup operasi **Create, Read, Update, dan Delete (CRUD)** serta validasi dan error handling yang baik.  

🔐 **Menggunakan JWT (JSON Web Token)** untuk autentikasi dan otorisasi, memastikan hanya pengguna yang sah dapat mengakses API.  

## 📌 Features  
- ✅ **Create** - Menambahkan data student baru.  
- ✅ **Read** - Mendapatkan semua data atau berdasarkan ID.  
- ✅ **Update** - Memperbarui data student.  
- ✅ **Delete** - Menghapus data student.  
- ✅ **JWT Authentication** - Melindungi endpoint API dengan token berbasis JWT.  

## 🔍 Pengecekan  
- ✔️ **Password** minimal 8 karakter.  
- ✔️ **Email dan NIM** tidak boleh duplikat.  
- ✔️ **Error handling** untuk validasi input dan database.  
- ✔️ **Autentikasi JWT** untuk keamanan API.  

## 🛠️ Penerapan  
- 📌 **Models** - Representasi data student.  
- 📌 **Controllers** - Mengatur request & response API.  
- 📌 **Repositories** - Mengelola akses data dengan ADO.NET.  
- 📌 **Services** - Menangani logika bisnis API.  
- 📌 **Middleware JWT** - Mengelola autentikasi dan validasi token JWT.  

## 🚀 Cara Menjalankan  

1️⃣ **Jalankan Query Database**  
   - Buka **PostgreSQL** dan eksekusi file query untuk membuat schema, tabel, dan data awal:  

2️⃣ **Konfigurasi Koneksi Database**  
   - Edit file **`appsettings.json`** dan sesuaikan dengan konfigurasi database PostgreSQL Anda:  
     ```json
     "ConnectionStrings": {
       "WebApiDatabase": "Host=localhost;Port=5432;Database=your_database;Username=your_user;Password=your_password;"
     }
     ```

3️⃣ **Jalankan API di Visual Studio**  
   - Buka **Visual Studio 2022**, lalu pilih **Run** atau gunakan terminal:  
     ```sh
     dotnet run
     ```
   - API akan berjalan di **`http://localhost:5000`** (atau port yang dikonfigurasi).  

4️⃣ **Akses API di Swagger**  
   - Buka browser dan kunjungi:  
     ```
     http://localhost:5000/swagger/api/student/
     ```
   - Gunakan Swagger UI untuk menguji API langsung dari browser.  

5️⃣ **Testing API di Postman**  
   - Import koleksi **Postman** (jika ada).  
   - Gunakan metode **POST, GET, PUT, DELETE** untuk menguji API.  
   - Tambahkan **Bearer Token** di tab **Authorization** untuk endpoint yang memerlukan autentikasi.  

## 🔧 Tools  
- 🔹 **Visual Studio 2022 Community Edition**  
- 🔹 **C# (.NET 6/7/8)**  
- 🔹 **PostgreSQL 17**  
- 🔹 **JWT Authentication**  
- 🔹 **Swagger & Postman**  

💡 **Tertarik untuk mencoba?** Jangan lupa ⭐ repo ini! 🚀😊  
