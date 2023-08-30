﻿using AutoMapper;
using Core;
using Core.Service;
using MaisTransporteWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace MaisTransporteWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService usuarioService;
        private readonly IMapper mapper;

        public UsuarioController(IUsuarioService usuarioService, IMapper mapper)
        {
            this.usuarioService = usuarioService;
            this.mapper = mapper;
        }

        // GET: UsuarioController
        public ActionResult Index()
        {
            var listaUsuarios =  usuarioService.GetAll();
            var listaUsuariosViewModel = mapper.Map<List<UsuarioViewModel>>(listaUsuarios);
            return View(listaUsuariosViewModel);
        }

        // GET: UsuarioController/Details
        public ActionResult Details(int id)
        {
            var usuario = usuarioService.Get(id);
            var usuarioViewModel = mapper.Map<UsuarioViewModel>(usuario);
            return View(usuarioViewModel);
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                var Usuario = mapper.Map<Usuario>(usuarioViewModel);
                usuarioService.Create(Usuario);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
