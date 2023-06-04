<?php
// Establecer la conexión con la base de datos
include 'conexion.php';

// Validar los datos recibidos
// Obtener el JSON recibido y decodificarlo
$json = file_get_contents('php://input');
$data = json_decode($json, true);

// Validar los datos recibidos
if (isset($data['nombre']) && isset($data['precio']) && isset($data['estado']) && isset($data['descuento_estado']) && isset($data['descuento']) && isset($data['delivery_estado']) && isset($data['descripcionC']) && isset($data['descripcionL']) && isset($data['imagen']) && isset($data['id_empresa'])) {
    $nombre = $data['nombre'];
    $precio = $data['precio'];
    $estado = $data['estado'];
    $descuento_estado = $data['descuento_estado'];
    $descuento = $data['descuento'];
    $delivery_estado = $data['delivery_estado'];
    $descripcionC = $data['descripcionC'];
    $descripcionL = $data['descripcionL'];
    $imagen = $data['imagen'];
    $id_empresa = $data['id_empresa'];
    

    // Insertar los datos en la tabla "empresas"
    $sql = "INSERT INTO `producto` (`nombre`, `precio`, `estado`, `descuento_estado`, `descuento`, `delivery_estado`, `descripcionC`, `descripcionL`, `imagen`,`id_empresa`) VALUES ('$nombre', '$precio', '$estado', '$descuento_estado', '$descuento', '$delivery_estado', '$descripcionC', '$descripcionL', '$imagen','$id_empresa')";

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