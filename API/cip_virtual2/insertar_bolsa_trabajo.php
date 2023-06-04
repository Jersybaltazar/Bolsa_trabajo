<?php
include 'conexion.php';

$json = file_get_contents('php://input');
$data = json_decode($json, true);

if (isset($data['id_usuario']) && isset($data['descripcion']) && isset($data['estado']) && isset($data['contacto']) && isset($data['contacto2'])) {
    $id_usuario=$data['id_usuario'];
    $descripcion=$data['descripcion'];
    $estado=$data['estado'];
    $contacto = $data['contacto'];
    $contacto2 = $data['contacto2'];

    $sql="INSERT INTO `bolsas_trabajo` (`id_usuario`, `descripcion`, `estado`, `contacto`, `contacto2`) VALUES ('$id_usuario', '$descripcion', '$estado', '$contacto', $contacto2)";

    if ($conn->query($sql) === TRUE) {
        echo "La bolsa de trabajo se ha guardado correctamente.";
    } else {
        echo "Error al guardar los datos: " . $conn->error;
    }
} else {
    echo "Inserte datos en la bolsa de trabajo.";
}
?>
<!---Insertar los datos mediante Json con este formato y/o Ayuda
{
    "id_usuario":"1",
    "descripcion":"Venta de bebidas alcolicas de puro trigo en su mas alta calidad",
    "estado":"2"
}
fin del ejemplo en formato json-->