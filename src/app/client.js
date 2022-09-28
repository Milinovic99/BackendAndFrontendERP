

var stripe = Stripe('pk_test_TYooMQauvdEDq54NiTphI7jx');
var checkoutButton = document.getElementById('checkout-button');

checkoutButton.addEventListener('click', function() {
  stripe.redirectToCheckout({
    sessionId: '{{CHECKOUT_SESSION_ID}}'
  }).then(function (result) {

  });
});
