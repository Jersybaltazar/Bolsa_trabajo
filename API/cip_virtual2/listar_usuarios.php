<?php
// Establecer la conexión con la base de datos
include 'conexion.php';

// Obtener los valores de los parámetros de la URL
$dni = isset($_GET['dni']) ? $_GET['dni'] : '';
$password = isset($_GET['password']) ? $_GET['password'] : '';

// Consulta SQL para buscar el usuario en la base de datos
$sql = "SELECT id_usuario,dni,nombre_usuario,apellidos,f_nacimiento,paternidad,foto,sexo FROM usuario WHERE dni='$dni' AND password ='$password'";
$result = $conn->query($sql);

// Verificar si se encontró el usuario en la base de datos
if ($result->num_rows > 0) {
    // Crear una lista JSON con los datos obtenidos de la base de datos
    $lista_json = array();
    while ($row = $result->fetch_assoc()) {
        $nombreImagen = $row['foto'];
        $carpetaDestino = 'C:\\IMG\\';
        $rutaImagen = $carpetaDestino . $nombreImagen;
        $imageData = file_get_contents($rutaImagen);
        $imagenCodificada = base64_encode($imageData);
        $item = array(
            'id_usuario' => $row['id_usuario'],
            'dni' => $row['dni'],
            'nombre_usuario' => $row['nombre_usuario'],
            'apellidos' => $row['apellidos'],
            'f_nacimiento' => $row['f_nacimiento'],
            'paternidad' => $row['paternidad'],
            'foto' => $imagenCodificada,
            'sexo' => $row['sexo'],
        );
        $lista_json[] = $item;
    }
    // Devolver la lista JSON como respuesta
    header('Content-Type: application/json');
    echo json_encode($lista_json);
} else {
    // Devolver un mensaje de error si el usuario no existe
    $error_msg = array(
        'error' => 'El usuario y la contraseña no existe.'
    );
    header('Content-Type: application/json');
    echo json_encode($error_msg);
}

// Cerrar la conexión a la base de datos
$conn->close();
?>