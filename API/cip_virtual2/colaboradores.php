<?php

// Establecer la conexión con la base de datos
include 'conexion.php';


// Obtener el valor del parámetro "nombre_usuario" de la URL
$usuario = isset($_GET['nombre_usuario']) ? $_GET['nombre_usuario'] : '';

// Consulta SQL para obtener los datos filtrados por nombre_usuario
$sql = "SELECT
        usuario.id_usuario AS id_usuario,
        usuario.nombre_usuario,
        usuario.apellidos AS apellido,
        g_academico.nombre AS grado_academico,
        usuario.Presentacion,
        experiencia.nombre AS experiencia,
        usuario.correo,
        usuario.telefono,
        usuario.registro_cip,
        usuario.url_cv,
        empleo.nombre AS empleo,
        usuario.foto,
        especialidad.nombre_especialidad
        FROM
        usuario
        INNER JOIN g_academico ON usuario.id_g_academico = g_academico.id_g_academico
        INNER JOIN experiencia ON usuario.id_experiencia = experiencia.id_experiencia
        INNER JOIN especialidad ON especialidad.id_usuario = usuario.id_usuario
        INNER JOIN empleo ON empleo.id_usuario = usuario.id_usuario ";
if (!empty($usuario)) {
    $sql .= " WHERE nombre_usuario LIKE '%$usuario%'";
}

$result = $conn->query($sql);

// Crear una lista JSON con los datos obtenidos de la base de datos
$lista_json = array();
if ($result->num_rows > 0) {
    while ($row = $result->fetch_assoc()) {
        $id_usuario = $row['id_usuario'];
        $especialidad = $row['nombre_especialidad'];
        $empleo=$row['empleo'];

        $nombreImagen = $row['foto'];
        $carpetaDestino = 'C:\\IMG\\';
        $rutaImagen = $carpetaDestino . $nombreImagen;
        $imageData = file_get_contents($rutaImagen);
        $imagenCodificada = base64_encode($imageData);

        // Si el usuario ya está en la lista, agregar la especialidad a su lista de especialidades
        if (isset($lista_json[$id_usuario])) {
            if (!in_array($especialidad,$lista_json[$id_usuario]['nombre_especialidad'])) {
                $lista_json[$id_usuario]['nombre_especialidad'][] = $especialidad;
            }
        
            if (!in_array($empleo, $lista_json[$id_usuario]['empleo'])) {
                $lista_json[$id_usuario]['empleo'][] = $empleo;
            }
        }
        // Si el usuario no está en la lista, agregarlo y crear una lista de especialidades con la primera especialidad
        else {
           
            $lista_json[$id_usuario] = array(
                'nombre_usuario' => $row['nombre_usuario'],
                'apellido' => $row['apellido'],
                'foto' => $imagenCodificada,
                'grado_academico' => $row['grado_academico'],
                'Presentacion' => $row['Presentacion'],
                'experiencia' => $row['experiencia'],
                'correo' => $row['correo'],
                'telefono' => $row['telefono'],
                'registro_cip' => $row['registro_cip'],
                'url_cv' => $row['url_cv'],
                'empleo' => array($empleo),
                'nombre_especialidad' => array($especialidad),
            );
        }
    }
}

// Devolver la lista JSON como respuesta
header('Content-Type: application/json');
echo json_encode(array_values($lista_json));


// Cerrar la conexión a la base de datos
$conn->close();

?>