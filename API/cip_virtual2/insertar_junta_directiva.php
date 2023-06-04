<?php
// Establecer la conexión con la base de datos
include 'conexion.php';

// Validar los datos recibidos
// Obtener el JSON recibido y decodificarlo
$json = file_get_contents('php://input');
$data = json_decode($json, true);

// Validar los datos recibidos
if (isset($data['nombre_ing']) && isset($data['cargo_ing']) && isset($data['foto_ing'])&& isset($data['link_ws'])) {
    $nombre_ing = $data['nombre_ing'];
    $cargo_ing = $data['cargo_ing'];
    $foto_ing = $data['foto_ing'];
    $link_ws = $data['link_ws'];

    // Insertar los datos en la tabla "empresas"
    $sql = "INSERT INTO junta_directiva (nombre_ing, cargo_ing, foto_ing, link_ws) VALUES ('$nombre_ing', '$cargo_ing', '$foto_ing','$link_ws')";

    if ($conn->query($sql) === TRUE) {
        echo "La junta directiva se ha guardado correctamente.";
    } else {
        echo "Error al guardar la junta directiva: " . $conn->error;
    }
} else {
    echo "Debe proporcionar los datos de la junta directiva.";
}

// Cerrar la conexión con la base de datos
$conn->close();
?>