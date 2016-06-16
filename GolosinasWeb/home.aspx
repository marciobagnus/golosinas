<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Distribuidora Ruta 19</title>
    <div id="ImagenGolosina" class="example1"></div>
 </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" Runat="Server">

    
    
<%--  
    <script src="web/js/jquery.scrollTo.js"></script>
    <script src="web/js/jquery.nav.js"></script>
    <script>
        $(document).ready(function () {
            $('#nav').onePageNav({
                begin: function () {
                    console.log('start')
                },
                end: function () {
                    console.log('stop')
                }
            });
        });
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            /*
            var defaults = {
                containerID: 'toTop', // fading element id
                containerHoverID: 'toTopHover', // fading element hover id
                scrollSpeed: 1200,
                easingType: 'linear' 
            };
            */

            $().UItoTop({ easingType: 'easeOutQuart' });

        });
    </script>
    <a href="#" id="toTop" style="display: block;"><span id="toTopHover" style="opacity: 1;"></span></a>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

      <div class="contact section" id="section-5">
        <div class="container">
            <h3 class="head">Contacto</h3>
            <div class="row">
                <div class="col-md-6">
                    <ul class="list">
                        <li class="list1">
                            <i class="icon1"></i>
                            <p class="address"><span class="phone">Teléfono :</span> 0351-15XXXXXXXX</p>
                            <div class="clearfix"></div>
                        </li>
                        <li class="list1">
                            <i class="icon2"></i>
                            <p class="address"><span class="phone">Email :</span><span class="email"><a href="mailto:info(at)fashion.com"> distribuidoraruta19@groppo.com.ar</a></span></p>
                            <div class="clearfix"></div>
                        </li>
                        <li class="list1 last">
                            <i class="icon4"></i>
                            <p class="address"><span class="phone">Dirección :</span> Ruta 19 Km 24</p>
                            <div class="clearfix"></div>
                        </li>
                    </ul>
                </div>
                <div class="col-md-6">
                    <div class="contact-form">
                        <form method="post" action="home.aspx">
                            <input type="text" class="textbox" value="Nombre" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Nombre';}">
                            <input type="text" class="textbox" value="Email" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Email';}">
                            <textarea value="Mensaje" onfocus="this.value= '';" onblur="if (this.value == '') {this.value = 'Mensaje';}">Mensaje</textarea>
                            <label class="btn2 btn-2 btn2-1b">
                                <input type="submit" value="Enviar" href="">
                            </label>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="footer_bottom">
        <div class="container">

            <ul class="social">
                <li><a href=""><i class="fb"></i></a></li>
                <li><a href=""><i class="rss"></i></a></li>
                <li><a href=""><i class="tw"></i></a></li>
            </ul>
        </div>
    </div>

</asp:Content>

