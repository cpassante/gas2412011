 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.core;
 using nothinbutdotnetstore.web.model;

namespace nothinbutdotnetstore.specs.web.core
{   
	public class LinkCommandSpecs
	{
		public abstract class concern : Observes
		{
        
		}

		[Subject(typeof(LinkCommand))]
		public class when_building_a_url : concern
		{

			Establish e = () =>
			{
				department = an<Department>();
				department.name = "Test";
			};

			It should_return_a_valid_url_for_the_department = () =>
				LinkCommand.GetName<ViewDepartmentsInDepartment>(department).ShouldEqual("ViewDepartmentsInDepartment.invision?Department=Test");

			It should_return_a_url_for_products_in_department = () =>
				LinkCommand.GetName<ViewProductsInDepartment>().ShouldEqual("ViewProductsInDepartment.invision");

			It should_return_a_valid_url_for_no_department = () =>
				LinkCommand.GetName<ViewDepartmentsInDepartment>(new Department()).ShouldEqual("ViewDepartmentsInDepartment.invision?Department=");

			static Department department;
				
		}
	}
}