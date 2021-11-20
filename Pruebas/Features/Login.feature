Feature: Login
  un usuario quiere iniciar sesión en la aplicación

@mytag
Scenario Outline: iniciar sesión o no iniciar sesión en la aplicación
    Given que somos un usuario
    When iniciamos sesión con "<usuario>" y "<contraseña>"
    Then el inicio de sesión "<respuesta>"
    Examples:
      | usuario | contraseña | respuesta |     
      | chino | 12345678 | LoginExitoso |
      | sssss | sssss | LoginNoEsExitoso |