// configuration of the observer:
var config = {
    attributes: true,
    childList: true,
    characterData: true,
    subtree: true,
    //attributeFilter:false
    attributeOldValue: true,
    characterDataOldValue: true
};

var hyperfeedid = "";
var reactionProtected;
var copyReaction;
var token = "";
var domain = "https://localhost/";

function findAncestor(el, cls) {
    while ((el = el.parentElement) && !el.classList.contains(cls));
    return el;
}

function Main_NewsFeed_Callback(mutations, observer) {
    mutations.forEach(function(mutation) {
        if (mutation.type === "childList") {
            if (mutation.addedNodes[0] == null) return null;
            if (mutation.addedNodes[0].nodeName.toLowerCase() === "div") {
                if (mutation.addedNodes[0].className === "_4ikz") {
                    if (mutation.addedNodes[0].children.length === 0) {
                        setTimeout(function() {
                            if (mutation.addedNodes[0].children.length === 0) console.log("empty 1");
                            else {
                                var div_class_4ikz = mutation.addedNodes[0];
                                if (hyperfeedid != div_class_4ikz.id) {
                                    var div_class_none = div_class_4ikz.lastChild;
                                    var div_id_u_jsonp_2_0 = div_class_none.lastChild;
                                    var dataft = div_id_u_jsonp_2_0.lastChild;
                                    if (dataft.children.length === 5) {
                                        hyperfeedid = div_class_4ikz.id;
                                        NewPosts(div_class_4ikz);
                                    } else {
                                        console.log("empty 2");
                                    }
                                }
                            }
                        }, 5000);
                    }
                }
            }
        }
        return null;
    });
}

function Home_feedstream_Post_observer_Callback(mutations, observer) {
    mutations.forEach(function(mutation) {
        if (mutation.type === "childList") {
            if (mutation.addedNodes[0] == null) return null;
            if (mutation.addedNodes[0].className === "_1oxj uiLayer") {
                observer.disconnect();
            }
        }
        return null;
    });
}

var bodyflag = 0;

function Facebook_Body_Callback(mutations, observer) {
    mutations.forEach(function(mutation) {
        if (mutation.type === "childList") {
            if (mutation.addedNodes[0] != null) {
                if (mutation.addedNodes[0].id != null) {
                    if (mutation.addedNodes[0].id === "photos_snowlift") {
                        var div_class_3t09 = mutation.addedNodes[0].getElementsByClassName("_3t09");
                        if (bodyflag === 0) {
                            bodyflag = 1;
                            Facebook_Popup_observer.observe(div_class_3t09[0], config);
                        }
                        observer.disconnect();
                    }
                }
            }
        }
    });
}

function Facebook_Popup_Callback(mutations, observer) {
    var pageid = null;
    var postid = null;
    var postlink = null;
    var div_class_fbPhotosSnowliftFeedback = null;
    var span_id_fbPhotoSnowliftTimestamp = null;
    mutations.forEach(function(mutation) {
        if (mutation.type === "childList") {
            if (mutation.addedNodes[0] != null) {
                if (mutation.addedNodes[0].className != null) {
                    if (mutation.addedNodes[0].className === "_hli") {
                        pageid = Parse_PageId(mutation.addedNodes[0]);
                    }
                    // this works from public popup
                    if (mutation.addedNodes[0].className === "_39g5" || mutation.addedNodes[0].className === "fbPhotosSnowliftFeedback") {
                        postid = Parse_PostId(mutation.addedNodes[0]);
                        postlink = Parse_PostLink(mutation.addedNodes[0]);

                    } // this works from private popup 
                    if (mutation.addedNodes[0].id != null) {
                        if (mutation.addedNodes[0].id === "fbPhotoSnowliftTimestamp") {
                            span_id_fbPhotoSnowliftTimestamp = mutation.addedNodes[0];
                            postid = Parse_PostId(span_id_fbPhotoSnowliftTimestamp.getElementsByClassName("_39g5")[0]);
                            postlink = Parse_PostLink(span_id_fbPhotoSnowliftTimestamp.getElementsByClassName("_39g5")[0]);
                        }
                    }
                    if (mutation.addedNodes[0].className === "fbPhotosSnowliftFeedback") {
                        div_class_fbPhotosSnowliftFeedback = mutation.addedNodes[0];
                    }
                    if (pageid != null && postid != null && postlink != null) {
                        if (div_class_fbPhotosSnowliftFeedback == null) {
                            var div_class_fbPhotoSnowliftContainer = findAncestor(span_id_fbPhotoSnowliftTimestamp, "fbPhotoSnowliftContainer");
                            div_class_fbPhotosSnowliftFeedback = div_class_fbPhotoSnowliftContainer.getElementsByClassName("fbPhotosSnowliftFeedback")[0];
                            console.log(div_class_fbPhotosSnowliftFeedback);
                            addControls(postlink, postid, pageid, div_class_fbPhotosSnowliftFeedback, "popup");
                        }
                    }
                }
            }
        }
    });
}

function Facebook_Page_Callback(mutations, observer) {
    mutations.forEach(function(mutation) {
        if (mutation.type === "childList") {
            if (mutation.addedNodes[0] == null) {
                return null;
            } else {
                if (mutation.addedNodes[0].className === "_1xnd") {
                    Page_Post(mutation.addedNodes[0].children);
                }
            }
        }
        return null;
    });
}

var Home_NewsFeed_observer = new MutationObserver(Main_NewsFeed_Callback);
var Home_feedstream2_Post_observer = new MutationObserver(Home_feedstream_Post_observer_Callback);
var Home_feedstream1_Post_observer = new MutationObserver(Home_feedstream_Post_observer_Callback);
var Facebook_Body_observer = new MutationObserver(Facebook_Body_Callback);
var Facebook_Popup_observer = new MutationObserver(Facebook_Popup_Callback);
var Facebook_Page_observer = new MutationObserver(Facebook_Page_Callback);


Main();

function Page_Post(div_class_4_u2_4u8) {
    for (var i = 0; i < div_class_4_u2_4u8.length; i++) {
        console.log(div_class_4_u2_4u8[i]);
        OnePost(div_class_4_u2_4u8[i]);
    }
}

function Main() {

    //chrome.runtime.sendMessage({
    //    cookiename: "copyReaction"
    //}, function(response) {
    //    if (response.copyReaction.toLowerCase() === "true") {
    //        copyReaction = true;
    //    } else if (response.copyReaction.toLowerCase() === "false") {
    //        copyReaction = false;
    //    }
    //});

    //chrome.runtime.sendMessage({
    //    cookiename: "reactionProtected"
    //}, function(response) {
    //    if (response.reactionProtected.toLowerCase() === "true") {
    //        reactionProtected = true;
    //    } else if (response.reactionProtected.toLowerCase() === "false") {
    //        reactionProtected = false;
    //    }
    //});

    //chrome.runtime.sendMessage({
    //    cookiename: "nawaz"
    //}, function(response) {
    //    token = response.token;
    //});

    Facebook_Body_observer.observe(document.getElementsByTagName("body")[0], config);

    // news feed
    // main header of news feed all news is contained in this i.e contentArea except the page timeline
    var div_id_contentArea = document.getElementById("contentArea");
    var div_id_pagelet_timeline_main_column = document.getElementById("pagelet_timeline_main_column");

    if (div_id_contentArea != null) {

        var div_id_contentArea_children = div_id_contentArea.firstChild;

        if (div_id_contentArea_children.id === "stream_pagelet") {
            var div_id_main_stream = div_id_contentArea_children.lastChild;

            var isHomeNewsFeed = div_id_main_stream.id.match(/topnews_main_stream_/g);
            if (isHomeNewsFeed != null) {
                //in main news feed stream_pagelet has five children I need the last child that is the 4 index	
                Home_NewsFeed(div_id_main_stream);
            }
            var isFriendListNewsFeed = div_id_main_stream.id.match(/friendlist_main_stream_/g);
            if (isFriendListNewsFeed != null) {
                //FriendList_NewsFeed(div_id_main_stream);
            }
        } else if (div_id_contentArea_children.id === "pagelet_group_") {
            //Group_NewsFeed(div_id_contentArea_children);
        } else if (div_id_contentArea_children.id == "") {

            var div_id_browse_result_area = div_id_contentArea_children.lastChild;
            if (div_id_browse_result_area.id == "browse_result_area") {
                // TopSearch_NewsFeed(div_id_browse_result_area);
            }
        } else if (div_id_contentArea.getElementsByClassName("fbTimelineCapsule clearfix") != null ||
            div_id_contentArea.getElementsByClassName("fbTimelineCapsule") != null) {

            var div_class_fbTimelineCapsule = div_id_contentArea.getElementsByClassName("fbTimelineCapsule")[0];

            var div_class_5nb8 = div_class_fbTimelineCapsule.firstChild;

            var div_class_2t4u_clearfix = div_class_5nb8.getElementsByTagName("ol");

            var div_class_5pcb_4b0l = div_class_2t4u_clearfix[0].firstChild;

            var div_class_5pcb_4b0l_children = div_class_5pcb_4b0l.children;

            for (var i = 0; i < div_class_5pcb_4b0l_children.length; i++) {
                //OnePost(div_class_5pcb_4b0l_children[i]);
            }
            //UserTimeline_observer.observe(div_class_5nb8,config);
        }
    } else if (div_id_pagelet_timeline_main_column != null) {
        Page_NewsFeed(div_id_pagelet_timeline_main_column);
    }
}

function Page_NewsFeed(div_id_pagelet_timeline_main_column) {
    var div_class_1xnd = div_id_pagelet_timeline_main_column.getElementsByClassName("_1xnd")[0];
    Page_Post(div_class_1xnd.children);
    Facebook_Page_observer.observe(div_id_pagelet_timeline_main_column, config);
}

function Home_NewsFeed(topnewsMainStream) {

    var topnewsMainStreamChildren = topnewsMainStream.children;
    var feedstream = topnewsMainStreamChildren[0].children;
    // at start of the facebook newsfeed only two posts are loaded and all the rest posts are added to the third div

    NewPosts(feedstream[1]);
    Home_feedstream1_Post_observer.observe(feedstream[1], config);

    NewPosts(feedstream[2]);
    Home_feedstream2_Post_observer.observe(feedstream[2], config);

    if (((feedstream[3].children)[0] != null)) {
        //If the node is an element node, the nodeType property will return 1.
        if (((feedstream[3].children)[0]).nodeType === 1) {
            Home_NewsFeed_observer.observe((feedstream[3].children)[0], config);
        }
    }
}

function NewPosts(div_class_4ikz) {

    //check post type
    var div_class_none = div_class_4ikz.lastChild;
    //if (div_class_none == null) return null;

    var div_id_u_jsonp_2_0 = div_class_none.lastChild;
    //if (div_id_u_jsonp_2_0 == null) return null;

    var div_class_none2 = div_id_u_jsonp_2_0.lastChild;
    //if (div_class_none2 == null) return null;

    var five_data_ft = div_class_none2.children;

    for (var i = 0; i < five_data_ft.length; i++) {

        // if two facebook posts are same it is added in a list (li) to look like one post
        if (five_data_ft[i].getElementsByTagName("ul").length == 1) {
            //two pages/users shared the same post
            TwoPosts(five_data_ft[i]);
        } else {
            OnePost(five_data_ft[i]);
        }
    }
}

function TwoPosts(one_data_ft) {
    var ul_class_uiList = one_data_ft.getElementsByTagName("UL");
    if (ul_class_uiList != null) {
        var ul_class_uiList_children = ul_class_uiList[0].children;
        for (var j = 0; j < ul_class_uiList_children.length; j++) {

            var div_class_userContentWrapper_5pcr = ul_class_uiList_children[j].getElementsByClassName("userContentWrapper _5pcr");

            var postid = getPostId("none", div_class_userContentWrapper_5pcr[0]);
            var postlink = getPostId("getpostlink", div_class_userContentWrapper_5pcr[0]);
            var pageid = getPageId(div_class_userContentWrapper_5pcr[0]);

            if (postid != null && pageid != null) {
                addControls(postlink, postid, pageid, div_class_userContentWrapper_5pcr[0], "nonpopup");
            }
        }
    } else {
        console.log(div_class_5pcr);
    }
}

function OnePost(one_data_ft) {
    var div_class_userContentWrapper_5pcr = one_data_ft.getElementsByClassName("userContentWrapper _5pcr");
    if (div_class_userContentWrapper_5pcr != null) {
        //normal posts
        if (div_class_userContentWrapper_5pcr.length == 1) {

            var postid = getPostId("none", div_class_userContentWrapper_5pcr[0]);
            var postlink = getPostId("getpostlink", div_class_userContentWrapper_5pcr[0]);
            var pageid = getPageId(div_class_userContentWrapper_5pcr[0]);

            if (postid != null && pageid != null) {
                addControls(postlink, postid, pageid, div_class_userContentWrapper_5pcr[0], "nonpopup");
            } else {
                console.log("null");
            }
        } else if (div_class_userContentWrapper_5pcr.length > 1) {
            //user liked,commented,reacted,suggested,sponsered etc
            var postid = getPostId("none", div_class_userContentWrapper_5pcr[1]);
            var postlink = getPostId("getpostlink", div_class_userContentWrapper_5pcr[1]);
            var pageid = getPageId(div_class_userContentWrapper_5pcr[1]);

            if (postid != null && pageid != null) {
                addControls(postlink, postid, pageid, div_class_userContentWrapper_5pcr[1], "nonpopup");
            } else {
                console.log("null");
            }
        }
    }
}

// The page id is stored in the image of the post user
function getPageId(div_class_userContentWrapper_5pcr) {
    if (div_class_userContentWrapper_5pcr == null) return null;
    var anchor_data_hovercard = div_class_userContentWrapper_5pcr.getElementsByClassName("_5pb8 _8o _8s lfloat _ohe");
    return Parse_PageId(anchor_data_hovercard[0]);
}

function Parse_PageId(anchor_data_hovercard) {

    if (anchor_data_hovercard == null) return null;

    var pageId = decodeURIComponent(anchor_data_hovercard.getAttribute("data-hovercard"));
    // data-hovercard="/ajax/hovercard/page.php?id=8062627951"
    var replaced;
    var arr;
    if (pageId.includes("/ajax/hovercard/page.php?id=")) {
        // if the post is shared by the page
        replaced = pageId.replace("/ajax/hovercard/page.php?id=", "");
        arr = replaced.split("&");
        if (arr.length > 1) {
            return arr[0];
        } else {
            return replaced;
        }
    }
    // data-hovercard="/ajax/hovercard/user.php?id=8062627951"
    else if (pageId.includes("/ajax/hovercard/user.php?id=")) {

        // if the post is shared by a user 
        replaced = pageId.replace("/ajax/hovercard/user.php?id=", "");
        arr = replaced.split("&");

        if (arr.length > 1) {
            return arr[0];
        } else {
            return replaced;
        }
    } else {
        return null;
    }
}

// The post id is stored in the current time of the post. e.g (1 hr, 17 hr, 1 second etc )
function getPostId(type, div_class_userContentWrapper_5pcr) {

    if (div_class_userContentWrapper_5pcr == null) return null;
    var anchor_class_5pcq = div_class_userContentWrapper_5pcr.getElementsByClassName("_5pcq");
    if (type === "getpostlink") {
        return Parse_PostLink(anchor_class_5pcq[0]);
    } else {
        return Parse_PostId(anchor_class_5pcq[0]);
    }
}

function Parse_PostId(anchor_class_5pcq) {

    String.prototype.replaceAll = function(search, replacement) {
        var target = this;
        return target.replace(new RegExp(search, "g"), replacement);
    };

    if (anchor_class_5pcq == null) return null;

    var parse_anchor = document.createElement("a");
    parse_anchor.href = anchor_class_5pcq.getAttribute("href");


    // https://www.facebook.com/photo.php?fbid=10100939484711908&set=a.610151803738.2152893.713081&type=3
    // /antonantipovofficial/photos/a.355277937889521.83585.355022177915097/1093220400761934/?type=3
    //var anchor = '/antonantipovofficial/photos/a.355277937889521.83585.355022177915097/1093220400761934/?type=3'

    var arr = parse_anchor.href.replace("?", "/");
    arr = arr.replaceAll("&", "/");
    arr = arr.replaceAll("=", "/");
    arr = arr.replaceAll("https://www.facebook.com/", "");
    arr = arr.replaceAll("http://www.facebook.com/", "");
    arr = arr.replaceAll("//", "/");
    var arrr = arr.split("/");

    for (var i = 0; i < arrr.length; i++) {
        if (arrr[i].toLowerCase() === "fbid") {
            return arrr[i + 1];
        } else if (arrr[i].toLowerCase() === "posts") {
            return arrr[i + 1];
        } else if (arrr[i].toLowerCase() === "videos") {
            return arrr[i + 1];
        } else if (arrr[i].toLowerCase() === "photos") {
            return arrr[i + 2];
        } else if (arrr[i].toLowerCase() === "groups") {
            return arrr[i + 3];
        } else if (i === 4) {
            return arrr[i];
        }
    }
    return null;
}

function Parse_PostLink(anchor_class_5pcq) {

    if (anchor_class_5pcq == null) return null;

    var parse_anchor = document.createElement("a");
    parse_anchor.href = anchor_class_5pcq.getAttribute("href");

    //https://www.facebook.com/photo.php?fbid=10100939484711908&set=a.610151803738.2152893.713081&type=3

    return parse_anchor.href;
}

function addControls(postlink, postid, pageid, div_class_userContentWrapper_5pcr, flow) {

    // This contains two div the first is view of user reactions i.e reaction icons 
    // The second div is for comment share and like 
    //var form_async = div_class_userContentWrapper_5pcr.getElementsByTagName("FORM");
    var div_class_42nr = div_class_userContentWrapper_5pcr.getElementsByClassName("_42nr");

    if (flow === "nonpopup") {
        if (div_class_42nr[0] == null) return null;
        // the div with the class _42nr contains all the reaction (comments,like,love,haha,angry,wow,sad,share)
        var div_class_42nr_children = div_class_42nr[0].children;

        for (var i = 0; i < div_class_42nr_children.length; i++) {
            var span_class_none = div_class_42nr_children[i];
            var div_class_khz = span_class_none.firstChild;
            if (div_class_khz.className == "_khz") {
                if (div_class_khz.querySelector("#hdn_pageid_postid") == null) {
                    addHiddenInput(postlink, pageid, postid, div_class_khz);
                }
            }
        }
    }
    // check if the newly added button already exists or not
    // if not exists add a new button
    addSaveButton(postlink, postid, pageid, div_class_42nr[0], div_class_userContentWrapper_5pcr, flow);
    return null;
}


// adding this function to add hidden input if we will use it if we append the reactions in facebook
function addHiddenInput(postlink, pageid, postid, div_class_khz) {
    var hdninput = document.createElement("input");
    hdninput.type = "hidden";
    hdninput.id = "hdn_pageid_postid";
    hdninput.name = "hdn_pageid_postid";
    hdninput.value = pageid + "_" + postid + "_" + encodeURIComponent(postlink);
    div_class_khz.appendChild(hdninput);
}

function getPostLink(div_class_userContentWrapper_5pcr) {

    var div_class_5x46 = div_class_userContentWrapper_5pcr.querySelector("._5x46");
    var div_class_5va3 = div_class_5x46.lastChild;
    //if (div_class_5va3 != null) return null;

    var div_class_42ef = div_class_5va3.lastChild;
    //if (_42ef == null) return null;

    var div_class_5va4 = div_class_42ef.lastChild;
    //if (div_class_5va4 == null) return null;

    var div_class_ = div_class_5va4.lastChild;

    var div_class_6a_5u5j = div_class_.lastChild;
    //if (div_class_6a_5u5j == null) return null;

    var div_class_6a_5u5j_6b = div_class_6a_5u5j.lastChild;
    // if (div_class_6a_5u5j_6b == null) return null;

    var div_class_5pcp = div_class_6a_5u5j_6b.lastChild;

    var span_class_none = div_class_5pcp.firstChild;

    var span_class_fsmfwnfcg = span_class_none.lastChild;

    var anchor_class_5pcq = span_class_fsmfwnfcg.lastChild;
    return anchor_class_5pcq.getAttribute("href");

}

function addSaveButton(postlink, postid, pageid, div_class_42nr, div_class_userContentWrapper_5pcr, flow) {

    if (div_class_42nr.querySelector("#kino") == null) {

        var newItem = document.createElement("span"); // Create a <li> node
        newItem.className = "tooltip";

        var div_tooltip = document.createElement("div");
        div_tooltip.className = "tooltiptext";
        div_tooltip.innerText = "Analyze Comments";
        newItem.appendChild(div_tooltip);

        var dropdown = document.createElement("div");
        dropdown.style.display = "inline-block";
        dropdown.id = "kino";

        var link2 = document.createElement("a");
        link2.href = "http://localhost/facebook?id=" + pageid + "_" + postid; // 146505212039213_2464275336928844";
        link2.target = "blank";

        var img = document.createElement("img");
        img.src = chrome.extension.getURL("images/icon_analyze.png");
        img.style.width = "20px";
        img.style.height = "20px";

        link2.appendChild(img);
        dropdown.appendChild(link2);
        newItem.appendChild(dropdown);
        div_class_42nr.appendChild(newItem);
    }
}