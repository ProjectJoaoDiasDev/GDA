const viewStudent = {
    data() {
        return {
            studentSearch: "",
            studentsViewModel: [],
            studentViewModelEdit: {
                address: {

                }
            },
            studentViewModel: {
                name: null,
                schoolClass: null,
                contactNumberMain: null,
                responsible: null,
                comments: null,
                contactNumberSecondary: null,
                birthDate: null,
                email: null,
                cpf: null,
                rg: null,
                active: true,
                address: {
                    cep: null,
                    district: null,
                    city: null,
                    uf: null,
                    complement: null,
                    publicplace: null,
                    observation: null,
                },
                studentManager: null,

            },
            listStudentViewModel: [],
            filterStudents: {
                birthDate: null,
                student: null,
                schoolClass: null,
                active: true,
            },
        };
    },
    methods: {
        getStudents() {
            var thisVue = this;
            $.ajax({
                type: "GET",
                url: "/Student/GetAll",
                success: function (resp) {
                    thisVue.studentsViewModel = resp;

                },
            });
        },
        getStudent(id) {
            var thisVue = this;
            $.ajax({
                type: 'GET',
                url: '/Student/GetById?id=' + id,
                success: function (resp) {
                    thisVue.studentViewModelEdit = resp;
                    thisVue.studentViewModelEdit = resp.active

                }
            })
        },
        formatDate(data, format) {
            if (data == null) return "";
            if (format == null) format = "DD/MM/YYYY";

            return moment(String(data)).format(format);
        },
        updateStudent(student) {
            var thisVue = this;
            $.ajax({
                type: "PUT",
                url: "/Student/Edit",
                data: JSON.stringify(student),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (resp) {
                    if (resp) {
                        thisVue.getStudents();
                    }
                },
                error: function (error) {
                    console.error(error);
                }
            });
        },
        showModal: function (name) {
            $('#' + name).modal('show');
        }
    },
    created() {
        this.getStudents();
        this.studentViewModelEdit = JSON.parse(JSON.stringify(this.studentViewModel));
    },
    mounted() {
    },
    watch: {
        studentSearch: function (str) {
            var thisVue = this;

            if (str == "") {
                thisVue.getStudents(str);
                return;
            }

            var student = [];
            thisVue.studentsViewModel.forEach((std) => {
                if (
                    String(student.name.toLowerCase()).includes(String(str.toLowerCase()))
                ) {
                    student.push(std);
                }
            });

            if (student != undefined && student.length > 0) {
                thisVue.studentsViewModel = student;
            }
        }
    }
}

Vue.createApp(viewStudent).mount('#viewStudent');