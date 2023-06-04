<?php

// Establecer la conexión con la base de datos
include 'conexion.php';


// Obtener el valor del parámetro "razon_social" de la URL
$nombre_documento = isset($_GET['nombre_documento']) ? $_GET['nombre_documento'] : '';

// Consulta SQL para obtener los datos filtrados por razon_social
// las tablas modificadas son tipo_documento a tipo; nombre del documento comparta igual a nombre_documento
$sql = "SELECT
        comparta_documento.id,
        comparta_documento.nombre_documento,
        tipo_documento.tipo,
        categoria_documento.categoria_documento,
        comparta_documento.otros AS otros,
        comparta_documento.img_ruta AS imagen,
        comparta_documento.descripcion,
        usuario.apellidos,
        usuario.nombre_usuario,
        comparta_documento.fuente
        FROM
        comparta_documento
        INNER JOIN tipo_documento ON comparta_documento.id_tipoDocumento = tipo_documento.id
        INNER JOIN categoria_documento ON comparta_documento.id_categoria = categoria_documento.id
        INNER JOIN usuario ON comparta_documento.id_usuario = usuario.id_usuario";
        
if (!empty($nombre_documento)) {
    $sql .= " WHERE nombre_documento LIKE '%$nombre_documento%'";
}
        

$result = $conn->query($sql);

// Crear una lista JSON con los datos obtenidos de la base de datos
$lista_json = array();
if ($result->num_rows > 0) {
    while ($row = $result->fetch_assoc()) {
        $item = array(
            'nombre_documento' => $row['nombre_documento'],
            'tipo' => $row['tipo'],
            'categoria_documento' => $row['categoria_documento'],
            'otros' => $row['otros'],
            'imagen' => $row['imagen'],
            'descripcion' => $row['descripcion'],
            'nombre_usuario' => $row['nombre_usuario'],
            'apellidos' => $row['apellidos'],
            'fuente' => $row['fuente'],
        );
        $lista_json[] = $item;
    }
}

// Devolver la lista JSON como respuesta
header('Content-Type: application/json');
echo json_encode($lista_json);

// Cerrar la conexión a la base de datos
$conn->close();

?>