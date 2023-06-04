<?php
// Establecer la conexión con la base de datos
include 'conexion.php';

// Validar los datos recibidos
// Obtener el JSON recibido y decodificarlo
$json = file_get_contents('php://input');
$data = json_decode($json, true);

// Validar los datos recibidos
if (isset($data['texto_sugerencia']) && isset($data['contactame']) && isset($data['id_usuario'])) {
    
    $texto_sugerencia = $data['texto_sugerencia'];
    $contactame = $data['contactame'];
    $id_usuario = $data['id_usuario'];

    // Insertar los datos en la tabla "empresas"
    $sql = "INSERT INTO sugerencia (texto_sugerencia, contactame, id_usuario) 
    VALUES ('$texto_sugerencia', '$contactame', '$id_usuario')";

    if ($conn->query($sql) === TRUE) {
        echo "La empresa se ha guardado correctamente.";
    } else {
        echo "Error al guardar la empresa: " . $conn->error;
    }
} else {
    echo "Debe proporcionar los datos de la empresa.";
}

// Cerrar la conexión con la base de datos
$conn->close();
?>