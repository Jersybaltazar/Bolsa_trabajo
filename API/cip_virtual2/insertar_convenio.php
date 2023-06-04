<?php
// Establecer la conexión con la base de datos
include 'conexion.php';

// Validar los datos recibidos
// Obtener el JSON recibido y decodificarlo
$json = file_get_contents('php://input');
$data = json_decode($json, true);

// Validar los datos recibidos
if (isset($data['entidad']) && isset($data['direccion']) && isset($data['pagina']) && isset($data['firma']) && isset($data['contacto'])) {
    $entidad = $data['entidad'];
    $direccion = $data['direccion'];
    $pagina = $data['pagina'];
    $firma = $data['firma'];
    $contacto = $data['contacto'];


    // Insertar los datos en la tabla "empresas"
    $sql = "INSERT INTO `convenios` (`entidad`, `direccion`, `pagina`, `firma`, `contacto`) VALUES ('$entidad', '$direccion', '$pagina', '$firma', '$contacto')";

    if ($conn->query($sql) === TRUE) {
        echo "La entidad se ha guardado correctamente.";
    } else {
        echo "Error al guardar la empresa: " . $conn->error;
    }
} else {
    echo "Debe proporcionar los datos de la entidad.";
}

// Cerrar la conexión con la base de datos
$conn->close();
?>