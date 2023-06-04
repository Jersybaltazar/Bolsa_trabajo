<?php
include 'conexion.php';

$json = file_get_contents('php://input');
$data = json_decode($json, true);

if (isset($data['ruc']) && isset($data['ruta_imagen']) && isset($data['razon_social']) && isset($data['direcion']) 
    && isset($data['ubicacion']) && isset($data['catalogo']) && isset($data['celular']) && isset($data['telefono']) && isset($data['pagina_web']) 
    && isset($data['face']) && isset($data['watsap']) && isset($data['instagram']) && isset($data['otros'])) {
        
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

        $sql="INSERT INTO `empresa` (`ruc`, `ruta_imagen`, `razon_social`, `direcion`, `ubicacion`, `catalogo`, `celular`, `telefono`, `pagina_web`, `face`, `watsap`, `instagram`, `otros`) VALUES ('$ruc', '$ruta_img', '$razon_social', '$direccion', '$ubicacion', '$catalogo', '$celular', '$telefono', '$pagina_web', '$face', '$whatsapp', '$instagram', '$otros')";
        
        if ($conn->query($sql) === TRUE) {
            echo "La Tienda se ha guardado correctamente";
        } else {
            echo "Error en guardar la tienda".$conn->error;
        }
        

} else {
    echo "Proporcione los datos de la tienda";
}

$conn->close();
?>

<!----Formato Json
{
    "ruc":"0000012",
    "ruta_imagen":"donofrio.jpg",
    "razon_social":"Donofrio",
    "direcion":"Calle Luis Galvani 493",
    "ubicacion":"Calle Luis Galvani 493",
    "catalogo":"Alimentos",
    "celular":"963852741",
    "telefono":"080010210",
    "pagina_web":"https://www.donofrio.com.pe/",
    "face":"https://www.facebook.com/Nestleperu",
    "watsap":"(0800)10210",
    "instagram":"https://www.instagram.com/nestleperu/",
    "otros":"https://twitter.com/NestlePeru"
}
Fin frl formato JsonFormato Json-->