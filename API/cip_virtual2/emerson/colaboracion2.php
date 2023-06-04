<?php

// Establecer la conexión con la base de datos
include 'conexion.php';


// Obtener el valor del parámetro "razon_social" de la URL
$usuario = isset($_GET['USUARIO']) ? $_GET['USUARIO'] : '';

// Consulta SQL para obtener los datos filtrados por razon_social
$sql = "SELECT
usuario.nombre AS USUARIO,
usuario.apellidos AS apellido,
g_academico.nombre AS `grado academico`,
usuario.Presentacion AS presentacion,
experiencia.nombre AS experiencia,
usuario.correo AS correo,
usuario.telefono AS telefono,
usuario.registro_cip as registro_cip,
usuario.url_cv AS url_cv,
especialidad.nombre AS especialidad,
categoria_documento.categoria_documento AS categoria
FROM
usuario
INNER JOIN g_academico ON usuario.id_g_academico = g_academico.id_g_academico
INNER JOIN experiencia ON usuario.id_experiencia = experiencia.id_experiencia
INNER JOIN especialidad ON usuario.id_especialidad = especialidad.id_especialidad ,
categoria_documento";
if (!empty($usuario)) {
    $sql .= " WHERE USUARIO LIKE '%$usuario%'";
}

$result = $conn->query($sql);

// Crear una lista JSON con los datos obtenidos de la base de datos
$lista_json = array();
if ($result->num_rows > 0) {
    while ($row = $result->fetch_assoc()) {
        $item = array(
            'USUARIO' => $row['USUARIO'],
            'apellido' => $row['apellido'],
            'grado academico' => $row['grado academico'],
            'presentacion' => $row['presentacion'],
            'experiencia' => $row['experiencia'],
            'correo' => $row['correo'],
            'telefono' => $row['telefono'],
            'registro_cip' => $row['registro_cip'],
            'url_cv' => $row['url_cv'],
            'especialidad' => $row['especialidad'],
            'categoria' => $row['categoria'],
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