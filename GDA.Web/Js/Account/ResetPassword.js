const appRedefinirSenha = {
    data() {
        return {
            email: "",
            postResetEnviado: false,
            senhaAlterada: false,
            novaSenha: "",
            confirmSenha: "",
            urlBase: "",
            show: {
                senha: false,
                confirmSenha: false
            }
        }
    },
    methods: {
        postEmailRecuperacao() {
            if (this.email.length == 0 || this.email.indexOf("@") == -1) {
                $("#erro").html("Email inválido");
                $("#erro").removeClass("d-none");
                return;
            }
            var thisvue = this;

            $.ajax({
                type: "post",
                url: "/account/obter-token-alterar-senha",
                contentType: "application/json",
                data: JSON.stringify(thisvue.email),
                success: function (resp) {
                    thisvue.postResetEnviado = true;
                },
                error: function (resp) {
                    $("#erro").html(resp.responseJSON);
                    $("#erro").removeClass("d-none");
                }
            });
        },


        postRedefinirSenha() {
            $("#novaSenha").removeClass("is-invalid");
            $("#confirmSenha").removeClass("is-invalid");
            $("#novaSenhaErro").addClass("d-none");
            $("#confirmSenhaErro").addClass("d-none");

            if (this.novaSenha.length == 0) {
                $("#novaSenhaErro").html("Digite uma senha");
                $("#novaSenhaErro").removeClass("d-none");
                $("#novaSenha").addClass("is-invalid");
                return;
            } else if (this.novaSenha.length < 8) {
                $("#novaSenhaErro").html("Senha dever ter no mínimo 8 caracteres");
                $("#novaSenhaErro").removeClass("d-none");
                $("#novaSenha").addClass("is-invalid");
                return;
            } else {
                $("#novaSenhaErro").addClass("d-none");
                $("#novaSenhaErro").html("");
            }

            if (this.novaSenha != this.confirmSenha) {
                $("#confirmSenhaErro").html("Senhas não conferem");
                $("#confirmSenhaErro").removeClass("d-none");
                $("#confirmSenha").addClass("is-invalid");
                return;
            }
            var thisvue = this;

            var uri = window.location.search.substring(1);
            var params = new URLSearchParams(uri);

            var suffix = JSON.parse(localStorage.getItem("suffix"));

            var novaSenha = {
                token: params.get("token"),
                suffix: suffix,
                userId: params.get("userId"),
                senha: this.novaSenha
            };

            $.ajax({
                type: "post",
                url: "/account/alterar-senha",
                contentType: "application/json",
                data: JSON.stringify(novaSenha),
                success: function (resp) {
                    thisvue.senhaAlterada = true;
                },
                error: function (resp) {
                    $("#erro").html(resp.responseText);
                    $("#erro").removeClass("d-none");
                    console.log(resp);
                }
            });

        }
    },

    mounted() {
    },

    watch: {
        "show.senha": function (show) {
            if (show) {
                $("#novaSenha").attr("type", "text");
            } else {
                $("#novaSenha").attr("type", "password");
            }
        },

        "show.confirmSenha": function (show) {
            if (show) {
                $("#confirmSenha").attr("type", "text");
            } else {
                $("#confirmSenha").attr("type", "password");
            }
        }
    }
}

Vue.createApp(appRedefinirSenha).mount('#viewRedefinir-senha');