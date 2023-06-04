<?php
// Establecer la conexión con la base de datos
include 'conexion.php';

// Validar los datos recibidos
// Obtener el JSON recibido y decodificarlo
$json = file_get_contents('php://input');
$data = json_decode($json, true);

// Validar los datos recibidos
if (isset($data['nombre']) && isset($data['link'])) {
    $nombre = $data['nombre'];
    $link = $data['link'];
    

    // Insertar los datos en la tabla "empresas"
    $sql = "INSERT INTO videos_interes (nombre, link) VALUES ('$nombre', '$link')";

    if ($conn->query($sql) === TRUE) {
        echo "el video de interes se guardo correctamente.";
    } else {
        echo "Error al guardar el video: " . $conn->error;
    }
} else {
    echo "Debe proporcionar los datos del video.";
}

// Cerrar la conexión con la base de datos
$conn->close();
?>