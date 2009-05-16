<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
  OpenIdAuth -- Register User
</asp:Content>
<asp:Content ID="Script1" ContentPlaceHolderID="headContent" runat="server">

  <script type='text/javascript'>
    $(function() {
      //Wire up the events

      $("#check-available-button").click(function() {
        //send out the hashed user id to the server
        console.log("in the click event");
        var userid = $("#UserName").val();
        $.getJSON("/Register/CheckUser", { username: userid },
      function(data) {
        if (!data.UserAvailable) {
          $("#username-div p")
            .text("Selected username not available")
            .css('display', 'block');
          $("#username-div").addClass("error");
        }
        else {
          $("#username-div").removeClass("error");
          $("#username-div p").css('display', 'none').text("");
        }
      });
      });
    });
  </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <h2>
    Register User</h2>
  <div>
    <%using (Html.BeginForm()) { %>
    <fieldset>
      <div id="username-div">
        <label for="UserName">
          UserName
        </label>
        <%=Html.TextBox("UserName") %>
        <input type='button' id="check-available-button" value='Check Availability!' />
        <p>
        </p>
      </div>
      <div id="images-div">
      </div>
      <div id="images-passwords-div">
      </div>
    </fieldset>
    <%} %>
  </div>
</asp:Content>
