using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using SQLitePCL;
using SETEC.Data.Entities;
using Npgsql;

namespace SETEC.Controllers
{
	public class AccesoController : Controller
	{
		private readonly Appdbcontext _context;

		public AccesoController(Appdbcontext context)
		{
			_context = context;
		}


		public IActionResult Acceso()
		{

			return View();

		}


		[HttpPost]
		public async Task<IActionResult> Acceso(string email, string password, string empresa)
		{

			var usuario = _context?.Usuarios.FirstOrDefault(p => p.email == email && p.password == password && p.empresa == empresa);
			if (usuario == null)
			{

				ViewBag.loginAccess = "Datos incorrectos, por favor vuelve a ingresar tus datos";
				return View();
			}
			else
			{
				var claims = new List<Claim> {
					new Claim(ClaimTypes.Name, usuario.usuario),
					new Claim("email", usuario.email),
					new Claim(ClaimTypes.Role, usuario.rol)
				};

				var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

			}

			ViewBag.User = usuario;
			return RedirectToAction("Index", "Home");
		}




		public async Task<IActionResult> exit()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

			return RedirectToAction("Acceso", "Acceso");

		}


	}
}

