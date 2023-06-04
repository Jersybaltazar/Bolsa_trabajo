<?php
// Establecer la conexión con la base de datos
include 'conexion.php';

// Validar los datos recibidos
// Obtener el JSON recibido y decodificarlo
$json = file_get_contents('php://input');
$data = json_decode($json, true);

// Validar los datos recibidos
if (isset($data['nombre']) && isset($data['id_tipoDocumento']) && isset($data['id_categoria']) && isset($data['otros'])  
&& isset($data['img_ruta']) && isset($data['descripcion'])) {
    
    $nombre = $data['nombre'];
    $id_tipoDocumento = $data['id_tipoDocumento'];
    $id_categoria = $data['id_categoria'];
    $otros = $data['otros'];
    $img_ruta = $data['img_ruta'];
    $descripcion = $data['descripcion'];
    

    // Insertar los datos en la tabla "empresas"
    $sql = "INSERT INTO comparta_documento (nombre, id_tipoDocumento, id_categoria, otros, img_ruta, descripcion) 
    VALUES ('$nombre', '$id_tipoDocumento', '$id_categoria', '$otros', '$img_ruta', '$descripcion')";

    if ($conn->query($sql) === TRUE) {
        echo "El libro se ha guardado correctamente.";
    } else {
        echo "Error al guardar el libro: " . $conn->error;
    }
} else {
    echo "Debe proporcionar los datos solicitados del libro.";
}

// Cerrar la conexión con la base de datos
$conn->close();
?>