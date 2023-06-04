<?php
include 'conexion.php';

$json = file_get_contents('php://input');
$data = json_decode($json, true);

if (isset($data['ruc']) && isset($data['ruta_imagen']) && isset($data['razon_social']) && isset($data['direcion']) 
    && isset($data['ubicacion']) && isset($data['catalogo']) && isset($data['celular']) && isset($data['telefono']) && isset($data['pagina_web']) 
    && isset($data['face']) && isset($data['watsap']) && isset($data['instagram']) && isset($data['otros']) && isset($data['id_usuario']) ) {
        
        $ruc=$data['ruc'];
        $ruta_img=$data['ruta_imagen'];
        $razon_social=$data['razon_social'];
        $direccion=$data['direcion'];
        $ubicacion=$data['ubicacion'];
        $catalogo=$data['catalogo'];
        $celular=$data['celular'];
        $telefono=$data['telefono'];
        $pagina_web=$data['pagina_web'];
        $face=$data['face'];
        $whatsapp=$data['watsap'];
        $instagram=$data['instagram'];
        $otros=$data['otros'];
        $id_usuario=$data['id_usuario'];

        $sql="INSERT INTO `empresa` (`ruc`, `ruta_imagen`, `razon_social`, `direcion`, `ubicacion`, `catalogo`, `celular`, `telefono`, `pagina_web`, `face`, `watsap`, `instagram`, `otros`,`id_usuario`) VALUES ('$ruc', '$ruta_img', '$razon_social', '$direccion', '$ubicacion', '$catalogo', '$celular', '$telefono', '$pagina_web', '$face', '$whatsapp', '$instagram', '$otros','$id_usuario')";
        
        if ($conn->query($sql) === TRUE) {
            echo "Se guardaron los datos de la tienda con EXITO!!!!!!";
        } else {
            echo "Error en guardar la tienda".$conn->error;
        }
        

} else {
    echo "Proporcione los datos de la tienda";
}

$conn->close();
?>
