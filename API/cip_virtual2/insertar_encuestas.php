<?php
// Establecer la conexión con la base de datos
include 'conexion.php';

// Validar los datos recibidos
// Obtener el JSON recibido y decodificarlo
$json = file_get_contents('php://input');
$data = json_decode($json, true);

// Validar los datos recibidos


if (isset($data['id_usuario']) && isset($data['link']))
 {
    $id_usuario = $data['id_usuario'];
    $link = $data['link'];
    
    // Insertar los datos en la tabla "empresas"
    $sql = "INSERT INTO encuentas(id_usuario, link) VALUES ('$id_usuario', '$link')";

    if ($conn->query($sql) === TRUE) {
        echo "La encuesta se ha guardado correctamente.";
    } else {
        echo "Error al guardar la encuesta: " . $conn->error;
    }
} else {
    echo "Debe proporcionar los datos de la encuesta.";
}

// Cerrar la conexión con la base de datos
$conn->close();
?>