﻿using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core.stubs;
using nothinbutdotnetstore.web.model;

namespace nothinbutdotnetstore.web.core
{
    public class ViewDepartmentInDepartment : ApplicationCommand
    {
        DepartmentsRepository repository;
        Renderer renderer;

        public ViewDepartmentInDepartment()
            : this(new StubDepartmentRepository(),
            new StubRenderer())
        {
        }

        public ViewDepartmentInDepartment(DepartmentsRepository repository, Renderer renderer)
        {
            this.repository = repository;
            this.renderer = renderer;
        }

        public void run(Request request)
        {
            renderer.display(repository.get_departments_in_department(request.map<Department>()));
        }
    }
}