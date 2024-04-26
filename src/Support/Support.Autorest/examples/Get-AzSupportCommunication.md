### Example 1: Get list of communications for a support ticket at subscription level
```powershell
 Get-AzSupportCommunication -SupportTicketName "3366336e-bc3faf4f-3970e063-e033-441f-8a49-1e6e1b55f05d"
```

```output
Name                                 Sender                             Subject                             CreatedDate
----                                 ------                             -------                             -----------
590629b9-44cb-ee11-9079-6045bdef700d support@mail.support.microsoft.com test - TrackingID#2403080040012292 3/9/2024 2:21:58 AM
ee25b14e-8fdd-ee11-904d-0022482a4908 support@mail.support.microsoft.com …                                  3/8/2024 9:03:35 PM
```

Lists all communications (attachments not included) for a support ticket.

### Example 2: Get communication for a support ticket at subscription level
```powershell
Get-AzSupportCommunication -SupportTicketName "3366336e-bc3faf4f-3970e063-e033-441f-8a49-1e6e1b55f05d" -Name "590629b9-44cb-ee11-9079-6045bdef700d"
```

```output
Body                   : <html><head>
                         <meta http-equiv="Content-Type" content="text/html; charset=utf-8"><meta name="Generator"
                         content="Microsoft Word 15 (filtered medium)"><style>
                         <!--
                         @font-face
                                {font-family:"Cambria Math"}
                         @font-face
                                {font-family:Calibri}
                         @font-face
                                {font-family:Aptos}
                         @font-face
                                {font-family:"Segoe UI"}
                         p.MsoNormal, li.MsoNormal, div.MsoNormal
                                {margin:0in;
                                font-size:12.0pt;
                                font-family:"Aptos",sans-serif}
                         a:link, span.MsoHyperlink
                                {color:blue;
                                text-decoration:underline}
                         span.EmailStyle19
                                {font-family:"Aptos",sans-serif;
                                color:windowtext}
                         .MsoChpDefault
                                {font-size:11.0pt}
                         @page WordSection1
                                {margin:1.0in 1.0in 1.0in 1.0in}
                         div.WordSection1
                                {}
                         -->
                         </style></head><body lang="EN-US" link="blue" vlink="purple"
                         style="word-wrap:break-word"><div class="WordSection1"><p class="MsoNormal"><span
                         style="font-size:11.0pt">You can close these cases, thanks.</span></p><p
                         class="MsoNormal"><span style="font-size:11.0pt">&nbsp;</span></p><p
                         class="MsoNormal"><b><span style="font-size:10.0pt; font-family:&quot;Segoe
                         UI&quot;,sans-serif; color:#505050">Test User <br></span></b><span
                         style="font-size:10.0pt; font-family:&quot;Segoe UI&quot;,sans-serif; color:#505050">Software
                         Engineer <br>Azure CXP <br><a href="mailto:test@test.com"><span
                         style="color:#467886">test@test.com</span></a> <br></span><br><img border="0"
                         width="115" height="28" id="Picture_x0020_1" src="cid:image001.png@01DA5F27.901D3F10"
                         data-attachment-id="4ccf9f08-e323-48e6-87a7-8d5d77f7a1fd" alt="Microsoft Logo"
                         style="width:1.1979in; height:.2916in"></p><p class="MsoNormal"><span
                         style="font-size:11.0pt">&nbsp;</span></p><div style="border:none; border-top:solid #E1E1E1
                         1.0pt; padding:3.0pt 0in 0in 0in"><p class="MsoNormal"><b><span style="font-size:11.0pt;
                         font-family:&quot;Calibri&quot;,sans-serif">From:</span></b><span style="font-size:11.0pt;
                         font-family:&quot;Calibri&quot;,sans-serif"> Melissa B
                         &lt;support@mail.support.microsoft.com&gt; <br><b>Sent:</b> Tuesday, February 13, 2024 11:43
                         AM<br><b>To:</b> Test User &lt;test@test.com&gt;; Microsoft Support
                         &lt;supportmail@microsoft.com&gt;<br><b>Cc:</b> Melissa Bermudez (Tek Experts)
                         &lt;v-mbermudez@microsoft.com&gt;<br><b>Subject:</b> RE: test -
                         TrackingID#2402130040005151</span></p></div><p
                         class="MsoNormal">&nbsp;</p><div><div><div><div><div><div><p class="MsoNormal"><span
                         style="font-size:11.0pt; font-family:&quot;Calibri&quot;,sans-serif">Hi
                         Jonathan,</span></p></div><div><p class="MsoNormal"><span style="font-size:11.0pt;
                         font-family:&quot;Calibri&quot;,sans-serif">&nbsp;</span></p></div><div><p
                         class="MsoNormal"><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,sans-serif;
                         color:black">Hope you are having a great day!<br>&nbsp;<br>Thank you for contacting Microsoft
                         support. My name is Melissa and I will be the Support Engineer working on your ticket
                         2402130040005151. &nbsp;All my contact information along with my manager can be found in my
                         signature at the end of this mail. Please do not hesitate to contact me at any point with
                         questions regarding this ticket.<br>&nbsp;<br>Below are the details including the initial
                         scope agreement for your issue:<br>As I understand, we are running a test. It is what we will
                         focus our investigation on and what we will use to determine if we have resolved your issue.
                         Let me know if there is anything missing or inaccurate.<br>&nbsp;<br>We will consider this
                         issue resolved when one of the following conditions are met:<br>1. &nbsp; &nbsp; &nbsp;
                         &nbsp; &nbsp; &nbsp;When we are able to solve our issue.<br>2. &nbsp; &nbsp; &nbsp; &nbsp;
                         &nbsp; &nbsp;A workaround has been provided that will allow you to solve your business
                         need.<br>3. &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;It has been clearly identified and/or
                         shown to you that what you are attempting to do cannot be supported by us.<br>4. &nbsp;
                         &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;The issue that you are experiencing is by
                         design.<br>&nbsp;<br>Microsoft works on 'one issue per incident' basis. As per Microsoft an
                         incident is defined as an issue that cannot be broken down any further. In case you have any
                         other issue after this, you would have to create a separate incident for it.</span><span
                         style="font-size:11.0pt; font-family:&quot;Calibri&quot;,sans-serif"><br></span>&nbsp;<span
                         style="font-size:11.0pt; font-family:&quot;Calibri&quot;,sans-serif"></span></p></div><div><p
                         class="MsoNormal"><u><span style="font-size:11.0pt;
                         font-family:&quot;Calibri&quot;,sans-serif">Findings and Next Actions</span></u><span
                         style="font-size:11.0pt;
                         font-family:&quot;Calibri&quot;,sans-serif">:</span></p></div><div><p class="MsoNormal"><span
                         style="font-size:11.0pt; font-family:&quot;Calibri&quot;,sans-serif"><br><span
                         style="color:black">Jonathan, we could see that there is another ticket created with the same
                         Subscription ID you provided, can you help us to confirm if our case is a duplicate of the
                         next tickets: &quot;2402120040012618&quot; and
                         &quot;2402120040012009&quot;?&nbsp;</span></span></p></div><div><p class="MsoNormal"><span
                         style="font-size:11.0pt;
                         font-family:&quot;Calibri&quot;,sans-serif">&nbsp;</span></p></div><div><p
                         class="MsoNormal"><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,sans-serif;
                         color:black">I still received confirmation, these cases that I told you are duplicates, but
                         could you confirm that this new case is also duplicate and if I can help you to close all 3,
                         or is it necessary to keep any of the cases open?</span><span style="font-size:11.0pt;
                         font-family:&quot;Calibri&quot;,sans-serif"><br><br><span style="color:black">In the
                         meantime, remember that if you need something else or have an additional question, you can
                         feel free to let me know, and I will be more than happy to assist you.<br>&nbsp;<br>Looking
                         forward to hearing back from you. Have a wonderful day!<br>&nbsp;<br>My best
                         regards,</span></span></p></div></div><div><div id="oldsignature"><div><div><p
                         class="MsoNormal"><strong><span style="font-size:11.0pt;
                         font-family:&quot;Calibri&quot;,sans-serif; color:#4472C4">Melissa
                         Bermudez</span></strong><span style="font-size:11.0pt;
                         font-family:&quot;Calibri&quot;,sans-serif"><br><span style="color:#7F7F7F">Support
                         Engineer</span><br><span style="color:#7F7F7F">Azure / Backup and Recovery
                         Services</span></span><span style="font-size:9.0pt; font-family:&quot;Segoe
                         UI&quot;,sans-serif"><br></span><span style="font-size:11.0pt;
                         font-family:&quot;Calibri&quot;,sans-serif; color:#7F7F7F">Email: </span><span
                         style="font-size:11.0pt; font-family:&quot;Calibri&quot;,sans-serif; color:black"><a
                         href="mailto:v-mbermudez@microsoft.com">v-mbermudez@microsoft.com</a></span><span
                         style="font-size:11.0pt; font-family:&quot;Calibri&quot;,sans-serif"><br><span
                         style="color:#7F7F7F">Working Hours: M to F - 7:00 AM to 4:00 PM CST </span></span><span
                         style="font-size:9.0pt; font-family:&quot;Segoe UI&quot;,sans-serif"><br></span><span
                         style="font-size:11.0pt; font-family:&quot;Calibri&quot;,sans-serif; color:#7F7F7F">Manager:
                         Allan Delgado /&nbsp;</span><span style="font-size:11.0pt;
                         font-family:&quot;Calibri&quot;,sans-serif"><a
                         href="mailto:v-aldelg@microsoft.com">v-aldelg@microsoft.com</a></span><span
                         style="font-size:9.0pt; font-family:&quot;Segoe
                         UI&quot;,sans-serif"><br><br></span><strong><span lang="ES-CR" style="font-size:11.0pt;
                         font-family:&quot;Calibri&quot;,sans-serif; color:#767171">Can’t reach
                         me?</span></strong><span style="font-size:11.0pt; font-family:&quot;Calibri&quot;,sans-serif;
                         color:#767171">&nbsp;Contact ABRS Help / </span><span style="font-size:11.0pt;
                         font-family:&quot;Calibri&quot;,sans-serif; color:black"><a
                         href="mailto:abrshelpdp@microsoft.com">abrshelpdp@microsoft.com</a></span><span
                         style="font-size:9.0pt; font-family:&quot;Segoe UI&quot;,sans-serif"></span></p></div></div></
                         div></div></div></div></div></div></div></body></html>
CommunicationDirection : Outbound
CommunicationType      : Web
CreatedDate            : 2/14/2024 2:24:16 PM
Id                     : /subscriptions/76cb77fa-8b17-4eab-9493-b65dace99813/providers/Microsoft.Support/supportTickets
                         /3366336e-bc3faf4f-3970e063-e033-441f-8a49-1e6e1b55f05d/communications/590629b9-44cb-ee11-9079
                         -6045bdef700d
Name                   : 590629b9-44cb-ee11-9079-6045bdef700d
ResourceGroupName      :
Sender                 : test@test.com
Subject                : RE: test - TrackingID#2402130040005151
Type                   : Microsoft.Support/communications
```

Returns communication details for a support ticket.