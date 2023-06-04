<?php
// Establecer la conexión con la base de datos
include 'conexion.php';

// Validar los datos recibidos
// Obtener el JSON recibido y decodificarlo
$json = file_get_contents('php://input');
$data = json_decode($json, true);

// Validar los datos recibidos
if (isset($data['nombre']) && isset($data['otros'])) {
    $nombre = $data['nombre'];
    $otros = $data['otros'];

    // Insertar los datos en la tabla "empresas"
    $sql = "INSERT INTO universidad_proc (nombre, otros) VALUES ('$nombre', '$otros')";

    if ($conn->query($sql) === TRUE) {
        echo "La Universidad se ha guardado correctamente.";
    } else {
        echo "Error al guardar la universidad: " . $conn->error;
    }
} else {
    echo "Debe proporcionar los datos de la universidad.";
}

// Cerrar la conexión con la base de datos
$conn->close();
?>