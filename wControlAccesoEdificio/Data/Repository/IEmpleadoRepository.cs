﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wControlAccesoEdificio.Entities;

namespace wControlAccesoEdificio.Data.Repository
{
    public interface IEmpleadoRepository
    {
        void Add(Empleado empleado);
        IEnumerable<Empleado> GetAll();
        Empleado GetById(int id);
        void Update(Empleado empleado);
        void Delete(int id);
    }
}
