using Microsoft.AspNetCore.Mvc;

namespace mvclab.Controllers;

public class LabController : Controller
{
	public IActionResult Info()
	{
		var labInfo = new
		{
			LabNumber = 1,
			Topic = "Розробка ASP.NET",
			Goal = "Створення проектів та робота з middleware",
			Name = "Алієв Омар"
		};

		return View(labInfo);

	}
}