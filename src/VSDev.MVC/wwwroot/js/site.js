function AjaxModal() {

    $(document).ready(function () {
        $(function () {
            $.ajaxSetup({ cache: false });

            $("#targetEndereco").on("click", "a[data-modal]", {}, function (e) {
                $("#modalEnderecoContent").load(this.href,
                    function () {
                        $("#modalEndereco").modal("show");
                        bindForm(this);
                    });
                return false;
            });
        });

        function bindForm(dialog) {
            var form = $("form", dialog);

            form.removeData("validator").removeData("unobtrusiveValidation");
            $.validator.unobtrusive.parse(form);

            form.submit(function () {
                $.ajax({
                    url: this.action,
                    type: this.method,
                    data: $(this).serialize(),
                    success: function (data) {
                        if (data.success) {
                            $("#modalEndereco").modal("hide");
                            $("#targetEndereco").load(data.url);
                        }
                        else {
                            $("#modalEnderecoContent").html(data);
                            bindForm(dialog);
                        }
                    }
                });
                return false;
            });
        }
    });

}

function BuscaCep() {
    $(document).ready(function () {
        function LimpaEndereco(value) {
            if (value == null) value = "";

            $("#Endereco_Logradouro").val(value);
            $("#Endereco_Bairro").val(value);
            $("#Endereco_Cidade").val(value);
            $("#Endereco_Estado").val(value);
        }

        $("#Endereco_Cep").blur(function () {
            var cep = $(this).val().replace(/\D/g, "");

            if (cep != "") {
                var validaCep = /^[0-9]{8}$/;

                if (validaCep.test(cep)) {
                    LimpaEndereco("...");

                    $.getJSON("https://viacep.com.br/ws/" + cep + "/json",
                        function (dados) {
                            if (!("erro" in dados)) {
                                $("#Endereco_Logradouro").val(dados.logradouro);
                                $("#Endereco_Bairro").val(dados.bairro);
                                $("#Endereco_Cidade").val(dados.localidade);
                                $("#Endereco_Estado").val(dados.uf);
                            }
                            else {
                                LimpaEndereco();
                                $("#msg_cep").html("O CEP informado não foi encontrado");
                            }
                        }
                    );
                }
                else {
                    LimpaEndereco();
                }
            }
            else {
                LimpaEndereco();
            }
        })
    })
}