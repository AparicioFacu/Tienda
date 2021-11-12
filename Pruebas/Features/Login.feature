Feature: Login
  un usuario quiere iniciar sesión en la aplicación

@mytag
Scenario Outline: iniciar sesión o no iniciar sesión en la aplicación
    Given que somos un usuario
    When iniciamos sesión con "<usuario>" y "<contraseña>"
    Then el inicio de sesión "<respuesta>"
    Examples:
      | usuario | contraseña | respuesta |     
      | 45412 | 123 | LoginExitoso |
      | sssss | sssss | LoginNoEsExitoso |