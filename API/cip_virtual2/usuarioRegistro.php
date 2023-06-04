<?php
// Establecer la conexión con la base de datos
include 'conexion.php';

// Validar los datos recibidos
// Obtener el JSON recibido y decodificarlo
$json = file_get_contents('php://input');
$data = json_decode($json, true);

// Validar los datos recibidos
if (
    isset($data['dni']) && isset($data['nombre_usuario']) && isset($data['apellidos']) && isset($data['direccion']) && isset($data['correo']) && isset($data['correo2']) && isset($data['telefono']) && isset($data['telefono2']) && isset($data['sexo'])
    && isset($data['f_nacimiento']) && isset($data['paternidad']) && isset($data['registro_cip']) && isset($data['tipo_colegiado']) && isset($data['password']) && isset($data['Presentacion']) && isset($data['url_cv']) && isset($data['foto']) && isset($data['id_carrera']) && isset($data['id_g_academico']) 
    && isset($data['id_experiencia']) && isset($data['id_autorizacion']) && isset($data['id_u_procedencia']) && isset($data['id_politicaPrivacidad'])
    && isset($data['id_busqueda_laboral'])
) {
    $dni = $data['dni'];
    $nombre = $data['nombre_usuario'];
    $apellidos = $data['apellidos'];
    $direccion = $data['direccion'];
    $correo = $data['correo'];
    $correo2 = $data['correo2'];
    $telefono = $data['telefono'];
    $telefono2 = $data['telefono2'];
    $sexo = $data['sexo'];
    $f_nacimiento = $data['f_nacimiento'];
    $paternidad = $data['paternidad'];
    $registro_cip = $data['registro_cip'];
    $tipo_colegiado = $data['tipo_colegiado'];
    $password = $data['password'];
    $Presentacion = $data['Presentacion'];
    $url_cv = $data['url_cv'];

    //insersion de imagen 
    $fotoBase64 = $data['foto'];
    $fotoBytes = base64_decode($fotoBase64);
    // Guardar la imagen en una carpeta en el servidor
    $carpetaDestino = 'C:\\IMG\\';
    $nombreArchivo = uniqid($nombre) . '.jpg'; // Generar un nombre único para el archivo
    $rutaCompleta = $carpetaDestino . $nombreArchivo;
    file_put_contents($rutaCompleta, $fotoBytes);
    // fin de la insersion 

    $id_carrera = $data['id_carrera'];
    $id_g_academico = $data['id_g_academico'];
    $id_experiencia = $data['id_experiencia'];
    $id_autorizacion = $data['id_autorizacion'];
    $id_u_procedencia = $data['id_u_procedencia'];
    $id_politicaPrivacidad = $data['id_politicaPrivacidad'];
    $id_busqueda_labora =$data['id_busqueda_laboral'] ;

    // Insertar los datos en la tabla "empresas"
    // $sql = "INSERT INTO usuario (dni, nombre, apellidos, direccion, correo, correo2, telefono, telefono2, sexo, f_nacimiento, paternidad, registro_cip, tipo_colegiado, password, Presentacion, url_cv, foto, id_carrera, id_g_academico, id_especialidad, id_experiencia, id_empelo, id_autorizacion, id_u_procedencia, id_politicaPrivacidad) VALUES ('$dni', '$nombre', '$apellidos', '$direccion', '$correo'
    // , '$correo2', '$telefono', '$telefono2', '$sexo', '$f_nacimiento', '$paternidad', '$registro_cip', '$tipo_colegiado', '$password', '$Presentacion', '$url_cv', '$foto', '$id_carrera', '$id_g_academico', '$id_especialidad', '$id_experiencia', '$id_empelo', '$id_autorizacion', '$id_u_procedencia', '$id_politicaPrivacidad')";
    $sql = "INSERT INTO usuario (dni, nombre_usuario, apellidos, direccion, correo, correo2, telefono, telefono2, sexo, f_nacimiento, paternidad, registro_cip, tipo_colegiado, password, Presentacion, url_cv, foto, id_carrera, id_g_academico, id_experiencia, id_autorizacion, id_u_procedencia, id_politicaPrivacidad, id_busqueda_laboral) VALUES ('$dni', '$nombre', '$apellidos', '$direccion', '$correo', '$correo2', '$telefono', '$telefono2', '$sexo', '$f_nacimiento', '$paternidad', '$registro_cip', '$tipo_colegiado', '$password', '$Presentacion', '$url_cv', '$nombreArchivo', '$id_carrera', '$id_g_academico', '$id_experiencia','$id_autorizacion', '$id_u_procedencia', '$id_politicaPrivacidad','$id_busqueda_labora')";
    if ($conn->query($sql) === TRUE) {
        echo "El usuario se ha guardado correctamente.";
    } else {
        echo "Error al guardar usuario: " . $conn->error;
    }
} else {
    echo "Debe proporcionar los datos del usuario.";
}



// Cerrar la conexión con la base de datos
$conn->close();

?>
