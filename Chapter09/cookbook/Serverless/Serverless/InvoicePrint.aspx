<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvoicePrint.aspx.cs" Inherits="Serverless.InvoicePrint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Invoice</title>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <link href="css/invoice.css" rel="stylesheet" />
    <script type="text/javascript">
        function ToggleErrorDisplay()
        {
            if ($("#errorDetails").is(":visible")) {
                $("#errorDetails").hide();
            } else {
                $("#errorDetails").show();
            }
        }

        function TogglePrintResult() {
            if ($("#printDetails").is(":visible")) {
                $("#printDetails").hide();
            } else {
                $("#printDetails").show();
            }
        }
    </script>
</head>
<body>
    <form runat="server">
        <div id="container">
            <%--<div>
                <img id="header_img" src="Content/wile-e-coyote.jpg" /></div>--%>
            <div id="main">
                <div id="header">
                    <div id="header_info black">The Software Company<span class="black">|</span> (072)-412-5920 <span class="black">|</span> software.com</div>
                </div>
                <h1 class="black" id="quote_name">Invoice INV00015</h1>
                <div id="client" style="float: right">
                    <div id="client_header">client:</div>
                    <p class="address black">
                        Mr. Wyle E. Coyote
                    </p>
                </div>
                <table id="phase_details">
                    <thead>
                        <tr>
                            <th class="title">Stock Code</th>
                            <th class="description">Item Description</th>
                            <th class="price">price</th>
                        </tr>
                    </thead>
                    <tr class="first black">
                        <td>BCR902I45</td>
                        <td>Acme Company Roadrunner Catch'em Kit</td>
                        <td class="price">
                            <div class="price_container">$300</div>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>Booster Skates</td>
                        <td class="price">
                            <div class="price_container">$200</div>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>Emergency Parachute</td>
                        <td class="price">
                            <div class="price_container">$100</div>
                        </td>
                    </tr>
                    <tr class="last">
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr class="first black">
                        <td>BFT547J78</td>
                        <td>Very Sneaky Trick Seed Kit</td>
                        <td class="price">
                            <div class="price_container">$800</div>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>Giant Magnet and Lead Roadrunner Seeds</td>
                        <td class="price">
                            <div class="price_container">$500</div>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>Rollerblades</td>
                        <td class="price">
                            <div class="price_container">$300</div>
                        </td>
                    </tr>
                    <tr class="last">
                        <td></td>
                        <td></td>
                        <td></td>
                    </tr>
                </table>
            </div>
            <div id="total_price">
                <h2>TOTAL: <span class="price black">$1100</span></h2>
            </div>
            <div id="print_link">
                <asp:LinkButton ID="lnkPrintInvoice" runat="server" Text="Print this invoice" OnClick="lnkPrintInvoice_Click"></asp:LinkButton>                
            </div>
            <div id="errorDetails">
                <asp:Label ID="lblErrorDetails" runat="server"></asp:Label>
            </div>
            <div id="printDetails">
                <asp:Label ID="lblPrintDetails" runat="server"></asp:Label>
            </div>
        </div>
    </form>

</body>
</html>
