<?php
// Establecer la conexión con la base de datos
include 'conexion.php';

// Obtener los datos recibidos y validarlos
$json = file_get_contents('php://input');
$data = json_decode($json, true);

if (isset($data['id_usuario']) && isset($data['empleos'])) {
    $id_usuario = mysqli_real_escape_string($conn, $data['id_usuario']);
    $empleos = mysqli_real_escape_string($conn, $data['empleos']);

    // Preparar la consulta para insertar los datos en la tabla "interes"
    $stmt = $conn->prepare("INSERT INTO interes (id_usuario, empleos) VALUES (?, ?)");
    $stmt->bind_param("is", $id_usuario, $empleos);

    if ($stmt->execute()) {
        echo "El interés de empleo se ha guardado correctamente.";
    } else {
        echo "Error al guardar el interés de empleo: " . $stmt->error;
    }

    // Cerrar la consulta preparada
    $stmt->close();
} else {
    echo "Debe proporcionar los datos del interés de empleo.";
}

// Cerrar la conexión con la base de datos
$conn->close();
?>